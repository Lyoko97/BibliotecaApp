using System;
using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaApp
{
    public partial class UserForm : Form
    {
        private TextBox txtNombre = new TextBox();
        private TextBox txtEmail = new TextBox();
        private ComboBox cboTipo = new ComboBox();
        private Button btnAceptar = new Button();
        private Button btnCancelar = new Button();

        public string Nombre { get => txtNombre.Text.Trim(); set => txtNombre.Text = value; }
        public string Email { get => txtEmail.Text.Trim(); set => txtEmail.Text = value; }
        public string Tipo { get => cboTipo.SelectedItem?.ToString() ?? ""; set => cboTipo.SelectedItem = value; }

        public UserForm()
        {
            InitializeComponent();
            BuildUi();
        }

        private void BuildUi()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new Size(420, 220);
            this.Text = "Usuario";

            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 4,
                Padding = new Padding(10)
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));

            void AddRow(string label, Control input)
            {
                var lbl = new Label { Text = label, Anchor = AnchorStyles.Left, AutoSize = true, Margin = new Padding(0, 6, 6, 6) };
                input.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                grid.Controls.Add(lbl);
                grid.Controls.Add(input);
            }

            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.Items.AddRange(new[] { "Estudiante", "Personal" });
            cboTipo.SelectedIndex = 0;

            AddRow("Nombre*", txtNombre);
            AddRow("Email", txtEmail);
            AddRow("Tipo*", cboTipo);

            var pnlBtns = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill };
            btnAceptar.Text = "Guardar";
            btnCancelar.Text = "Cancelar";
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnAceptar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(Nombre))
                { MessageBox.Show("El nombre es obligatorio."); return; }
                if (string.IsNullOrWhiteSpace(Tipo))
                { MessageBox.Show("Selecciona un tipo."); return; }
                this.DialogResult = DialogResult.OK;
            };

            pnlBtns.Controls.Add(btnAceptar);
            pnlBtns.Controls.Add(btnCancelar);
            grid.Controls.Add(new Label());
            grid.Controls.Add(pnlBtns);

            this.Controls.Add(grid);
        }
    }
}
