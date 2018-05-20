using PA.Core;
using PA.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA.Client
{
    public partial class Form1 : Form
    {
        private TcpClient currentClient;
        private const int receiveTimeout = 60 * 1000000;
        private const int sendTimeout = 60 * 1000000;
        private List<EmployeeModel> emps = new List<EmployeeModel>();
        private List<PositionModel> positions = new List<PositionModel>();
        private List<DepartmentModel> deps = new List<DepartmentModel>();
        private List<PayoutTypeModel> payoutTyeps = new List<PayoutTypeModel>();
        private List<PayoutModel> payouts = new List<PayoutModel>();        
        private int selectedEmpId = -1;        
        private int selectedPayoutId = -1;
        private int selectedDepId = -1;
        private int selectedPositionId = -1;

        public Form1()
        {
            InitializeComponent();

            cbPositions.DisplayMember = "Name";
            cbPositions.ValueMember = "Id";

            cbDepartments.DisplayMember = "Name";
            cbDepartments.ValueMember = "Id";

            cbPayoutType.DisplayMember = "Name";
            cbPayoutType.ValueMember = "Id";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            currentClient = new TcpClient(tbIp.Text, int.Parse(tbPort.Text));
            currentClient.SendTimeout = sendTimeout;
            currentClient.ReceiveTimeout = receiveTimeout;            
        }

        private void btnGetEmpsFromServer_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Получить сотрудников
            GetEmpsFromServer(formatter, stream);

            // Получить должности
            GetPositions(formatter, stream);

            // Отправить запрос на получение отделов
            GetDeps(formatter, stream);

            // Отправить запрос на получение типов выплат
            GetPayoutTypes(formatter, stream);
            
            // Заполнить таблицу сотрудников
            FillEmpsGrid();
        }

        private void GetEmpsFromServer(IFormatter formatter, NetworkStream stream)
        {            
            // Отправить запрос на получение всех сотрудников
            formatter.Serialize(stream, RequestTypes.GetEmps);

            // Получить сотрудников
            var response = (ResponseTypes)formatter.Deserialize(stream);
            emps = (List<EmployeeModel>)formatter.Deserialize(stream);            
        }

        /// <summary>
        /// Получить выплаты
        /// </summary>
        /// <param name="formatter"></param>
        /// <param name="stream"></param>
        private void GetPayoutTypes(IFormatter formatter, NetworkStream stream)
        {
            formatter.Serialize(stream, RequestTypes.GetPayoutTypes);

            ResponseTypes response = (ResponseTypes)formatter.Deserialize(stream);
            payoutTyeps = (List<PayoutTypeModel>)formatter.Deserialize(stream);

            cbPayoutType.DataSource = payoutTyeps;
        }

        /// <summary>
        /// Получить отделы
        /// </summary>
        /// <param name="formatter"></param>
        /// <param name="stream"></param>
        private void GetDeps(IFormatter formatter, NetworkStream stream)
        {
            formatter.Serialize(stream, RequestTypes.GetDepartments);

            ResponseTypes response = (ResponseTypes)formatter.Deserialize(stream);
            deps = (List<DepartmentModel>)formatter.Deserialize(stream);

            cbDepartments.DataSource = deps;
            FillDepartmentsGrid();
        }

        /// <summary>
        /// Заполнить таблицу отделов компании
        /// </summary>
        private void FillDepartmentsGrid()
        {
            dgvDeps.Rows.Clear();
            if (deps.Count > 0)
            {
                dgvDeps.RowCount = deps.Count;
                for (int i = 0; i < dgvDeps.RowCount; i++)
                {
                    dgvDeps.Rows[i].Cells["DepId"].Value = deps[i].Id;
                    dgvDeps.Rows[i].Cells["DepName"].Value = deps[i].Name;
                }
            }
        }

        /// <summary>
        /// Получить должности
        /// </summary>
        /// <param name="formatter"></param>
        /// <param name="stream"></param>
        private void GetPositions(IFormatter formatter, NetworkStream stream)
        {
            // Отправить запрос на получение должностей
            formatter.Serialize(stream, RequestTypes.GetPositions);

            ResponseTypes response = (ResponseTypes)formatter.Deserialize(stream);
            positions = (List<PositionModel>)formatter.Deserialize(stream);

            cbPositions.DataSource = positions;
            FillPositionsGrid();
        }

        private void FillPositionsGrid()
        {
            dgvPositions.Rows.Clear();
            if (positions.Count > 0)
            {
                dgvPositions.RowCount = positions.Count;
                for (int i = 0; i < dgvPositions.RowCount; i++)
                {
                    dgvPositions.Rows[i].Cells["PositionId"].Value = positions[i].Id;
                    dgvPositions.Rows[i].Cells["PositionName"].Value = positions[i].Name;
                }
            }
        }

        /// <summary>
        /// Заполнить таблицу сотрудников
        /// </summary>
        /// <param name="emps">Коллекция сотрудников</param>
        private void FillEmpsGrid()
        {
            dgvEmps.Rows.Clear();

            if (emps.Count > 0)
            {
                dgvEmps.RowCount = emps.Count;
                for (int i = 0; i < dgvEmps.RowCount; i++)
                {
                    dgvEmps.Rows[i].Cells["ID"].Value = emps[i].Id;
                    dgvEmps.Rows[i].Cells["FullName"].Value = $"{emps[i].LastName} {emps[i].FirstName} {emps[i].MiddleName}";
                    dgvEmps.Rows[i].Cells["Department"].Value = emps[i].Department;
                    dgvEmps.Rows[i].Cells["Position"].Value = emps[i].Position;
                }

                if (dgvEmps.RowCount > 0)
                {
                    dgvEmps.Rows[0].Cells["ID"].Selected = true;
                }
            }
        }

        private void dgvEmps_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedEmpId = (int)dgvEmps.Rows[e.RowIndex].Cells["ID"].Value;
            var emp = emps.Where(x => x.Id == selectedEmpId).FirstOrDefault();

            tbLastName.Text = emp.LastName;
            tbFirstName.Text = emp.FirstName;
            tbMiddleName.Text = emp.MiddleName;

            cbPositions.SelectedItem = positions
                .Where(x => x.Name == emp.Position)
                .FirstOrDefault();

            cbDepartments.SelectedItem = deps
                .Where(x => x.Name == emp.Department)
                .FirstOrDefault();

            gbPayouts.Text = $"Выплаты сотрудника {emp.LastName} {emp.FirstName} {emp.MiddleName}";
        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Отправить запрос на обновление информации о сотруднике
            formatter.Serialize(stream, RequestTypes.EditEmp);

            // Отправить новые данные сотрудника
            formatter.Serialize(stream, new EmployeeEditModel
            {
                Id = selectedEmpId,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                MiddleName = tbMiddleName.Text,
                PositionId = (int)cbPositions.SelectedValue,
                DepartmentId = (int)cbDepartments.SelectedValue
            });

            var response = (ResponseTypes)formatter.Deserialize(stream);

            switch(response)
            {
                case ResponseTypes.Data:
                    // Получить нового сотрудника с сервера
                    var newEmp = (EmployeeModel)formatter.Deserialize(stream);

                    // Обновить коллекцию
                    emps.Remove(emps.Where(x => x.Id == selectedEmpId).FirstOrDefault());
                    emps.Add(newEmp);

                    // Заполнить грид
                    FillEmpsGrid();                    
                    break;
                case ResponseTypes.Error:
                    var error = (string)formatter.Deserialize(stream);
                    MessageBox.Show(error);
                    break;
            }                   
        }

        private void btnRegisterEmp_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Послать запрос на создание сотрудника
            formatter.Serialize(stream, RequestTypes.CreateEmp);

            // Создать сотрудника
            formatter.Serialize(stream, new EmployeeModel
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                MiddleName = tbMiddleName.Text
            });

            // Проверить ответ
            var response = (ResponseTypes)formatter.Deserialize(stream);
            switch (response)
            {
                case ResponseTypes.Data:
                    var newEmp = (EmployeeModel)formatter.Deserialize(stream);
                    emps.Add(newEmp);
                    FillEmpsGrid();
                    break;
                case ResponseTypes.Error:
                    var error = (string)formatter.Deserialize(stream);
                    MessageBox.Show(error);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{cbPositions.SelectedValue} {((PositionModel)cbPositions.SelectedItem).Name}");
        }

        private void btnFireEmp_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Послать запрос на увольнение сотрудника
            formatter.Serialize(stream, RequestTypes.FireEmp);

            formatter.Serialize(stream, selectedEmpId);

            selectedEmpId = -1;

            formatter.Deserialize(stream);
            formatter.Deserialize(stream);

            GetEmpsFromServer(formatter, stream);
        }

        private void btnAssignPayout_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Послать запрос на создание выплаты
            formatter.Serialize(stream, RequestTypes.CreatePayout);

            formatter.Serialize(stream, new AssignPayoutModel
            {
                EmployeeId = selectedEmpId,
                PayoutTypeId = (int)cbPayoutType.SelectedValue,
                Sum = (double)nudSum.Value
            });

            formatter.Deserialize(stream);
            formatter.Deserialize(stream);
        }

        private void btnDeletePayout_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Послать запрос на удаление выплаты
            formatter.Serialize(stream, RequestTypes.RemovePayout);

            // Отправить id удаляемой выплаты
            formatter.Serialize(stream, selectedPayoutId);            
            formatter.Deserialize(stream);           

            // Удалить выплату из массива локально
            payouts.Remove(payouts.Where(x => x.Id == selectedPayoutId).FirstOrDefault());
            selectedPayoutId = -1;

            // Перезаполнить таблицу
            FillPayoutsGrid();            
        }

        private void btnUpdatePayout_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Послать запрос на обновление выплаты
            formatter.Serialize(stream, RequestTypes.EditPayout);

            // Послать id выплаты и сумму
            formatter.Serialize(stream, new EditPayoutModel
            {
                PayoutId = selectedPayoutId,
                Sum = (double)nudEditPayoutSum.Value
            });

            var updatedPayout = (PayoutModel)formatter.Deserialize(stream);

            var oldPayout = payouts.Where(x => x.Id == updatedPayout.Id).FirstOrDefault();
            updatedPayout.PayoutType = oldPayout.PayoutType;

            payouts.Remove(oldPayout);
            payouts.Add(updatedPayout);

            FillPayoutsGrid();
        }

        private void btnGetPayoutsForEmp_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Послать запрос на получение выплат
            formatter.Serialize(stream, RequestTypes.GetPayouts);

            formatter.Serialize(stream, selectedEmpId);

            payouts = (List<PayoutModel>)formatter.Deserialize(stream);
            FillPayoutsGrid();
        }

        private void FillPayoutsGrid()
        {
            dgvPayouts.Rows.Clear();
            if (payouts.Count > 0)
            {
                dgvPayouts.RowCount = payouts.Count;
                for (int i = 0; i < dgvPayouts.RowCount; i++)
                {
                    dgvPayouts.Rows[i].Cells["PayoutId"].Value = payouts[i].Id;
                    dgvPayouts.Rows[i].Cells["PayoutType"].Value = payouts[i].PayoutType;
                    dgvPayouts.Rows[i].Cells["Sum"].Value = payouts[i].Sum;
                }
            }
        }

        private void dgvPayouts_Click(object sender, EventArgs e)
        {
        }

        private void dgvPayouts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedPayoutId = (int)dgvPayouts.Rows[e.RowIndex].Cells["PayoutId"].Value;

            var payout = payouts.Where(x => x.Id == selectedPayoutId).FirstOrDefault();

            nudEditPayoutSum.Value = (decimal)payout.Sum;
        }

        private void btnDeleteDep_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Послать запрос на удаление отдела
            formatter.Serialize(stream, RequestTypes.RemoveDep);

            formatter.Serialize(stream, selectedDepId);
            selectedDepId = -1;

            formatter.Deserialize(stream);

            GetDeps(formatter, stream);
        }

        private void dgvDeps_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedDepId = (int)dgvDeps.Rows[e.RowIndex].Cells["DepId"].Value;

            var dep = deps.Where(x => x.Id == selectedDepId).FirstOrDefault();

            tbDepName.Text = dep.Name;
        }

        private void btnUpdateDep_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Послать запрос на обновление отдела
            formatter.Serialize(stream, RequestTypes.EditDepartment);
            
            formatter.Serialize(stream, new DepartmentModel
            {
                Id = selectedDepId,
                Name = tbDepName.Text
            });

            formatter.Deserialize(stream);
            GetDeps(formatter, stream);
        }

        private void btnCreateDep_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Послать запрос на обновление отдела
            formatter.Serialize(stream, RequestTypes.CreateDep);

            formatter.Serialize(stream, new DepartmentModel
            {
                Name = tbDepName.Text
            });

            formatter.Deserialize(stream);
            GetDeps(formatter, stream);
        }

        private void btnCreatePosition_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Послать запрос на обновление отдела
            formatter.Serialize(stream, RequestTypes.CreatePosition);

            formatter.Serialize(stream, new PositionModel
            {
                Name = tbPositionName.Text
            });

            formatter.Deserialize(stream);
            GetPositions(formatter, stream);
        }

        private void btnRemovePosition_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Послать запрос на удаление должности
            formatter.Serialize(stream, RequestTypes.RemovePosition);

            formatter.Serialize(stream, selectedPositionId);
            selectedPositionId = -1;

            formatter.Deserialize(stream);
            GetPositions(formatter, stream);
        }

        private void btnSavePosition_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = currentClient.GetStream();

            // Послать запрос на обновление должности
            formatter.Serialize(stream, RequestTypes.EditPosition);

            formatter.Serialize(stream, new PositionModel
            {
                Id = selectedPositionId,
                Name = tbDepName.Text
            });

            formatter.Deserialize(stream);
            GetPositions(formatter, stream);
        }

        private void dgvPositions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedPositionId = (int)dgvPositions.Rows[e.RowIndex].Cells["PositionId"].Value;

            var pos = positions.Where(x => x.Id == selectedPositionId).FirstOrDefault();

            tbPositionName.Text = pos.Name;
        }
    }
}
