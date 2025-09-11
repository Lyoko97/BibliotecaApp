using System;
using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaApp
{
    public partial class LibroForm : Form
    {
        private TextBox txtTitulo = new TextBox();
        private TextBox txtAutor = new TextBox();
        private TextBox txtAnio = new TextBox();
        private Button btnAceptar = new Button();
        private Button btnCancelar = new Button();

        public string Titulo { get => txtTitulo.Text.Trim(); set => txtTitulo.Text = value; }
        public string Autor { get => txtAutor.Text.Trim(); set => txtAutor.Text = value; }
        public int Anio { get => int.TryParse(txtAnio.Text, out var v) ? v : 0; set => txtAnio.Text = value.ToString(); }

        public LibroForm()
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
            this.ClientSize = new Size(400, 200);

            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 4,
                Padding = new Padding(10),
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));

            void AddRow(string label, Control input)
            {
                var lbl = new Label { Text = label, Anchor = AnchorStyles.Left, AutoSize = true };
                input.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                grid.Controls.Add(lbl);
                grid.Controls.Add(input);
            }

            AddRow("Título*", txtTitulo);
            AddRow("Autor", txtAutor);
            AddRow("Año*", txtAnio);

            var panelBtns = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill };
            btnAceptar.Text = "Guardar";
            btnCancelar.Text = "Cancelar";
            btnCancelar.DialogResult = DialogResult.Cancel;

            btnAceptar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(Titulo))
                { MessageBox.Show("El título es obligatorio."); return; }
                if (Anio <= 0)
                { MessageBox.Show("El año no es válido."); return; }

                this.DialogResult = DialogResult.OK;
            };

            panelBtns.Controls.Add(btnAceptar);
            panelBtns.Controls.Add(btnCancelar);
            grid.Controls.Add(new Label());
            grid.Controls.Add(panelBtns);

            this.Controls.Add(grid);
        }
    }
}
