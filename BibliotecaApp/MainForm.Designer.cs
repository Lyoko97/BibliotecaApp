namespace BibliotecaApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabLibros = new TabPage();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnAgregar = new Button();
            dataGridLibros = new DataGridView();
            tabUsuarios = new TabPage();
            btnEliminarUsuario = new Button();
            btnEditarUsuario = new Button();
            btnAgregarUsuario = new Button();
            dataGridUsuarios = new DataGridView();
            tabPrestamos = new TabPage();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            numDias = new NumericUpDown();
            cboLibro = new ComboBox();
            cboUsuario = new ComboBox();
            btnDevolver = new Button();
            btnPrestar = new Button();
            dataGridPrestamos = new DataGridView();
            tabDashboard = new TabPage();
            tabControl1.SuspendLayout();
            tabLibros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridLibros).BeginInit();
            tabUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridUsuarios).BeginInit();
            tabPrestamos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridPrestamos).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabLibros);
            tabControl1.Controls.Add(tabUsuarios);
            tabControl1.Controls.Add(tabPrestamos);
            tabControl1.Controls.Add(tabDashboard);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 426);
            tabControl1.TabIndex = 0;
            // 
            // tabLibros
            // 
            tabLibros.Controls.Add(btnEliminar);
            tabLibros.Controls.Add(btnEditar);
            tabLibros.Controls.Add(btnAgregar);
            tabLibros.Controls.Add(dataGridLibros);
            tabLibros.Location = new Point(4, 24);
            tabLibros.Name = "tabLibros";
            tabLibros.Padding = new Padding(3);
            tabLibros.Size = new Size(768, 398);
            tabLibros.TabIndex = 0;
            tabLibros.Text = "Libros";
            tabLibros.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(317, 256);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(187, 256);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(60, 256);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dataGridLibros
            // 
            dataGridLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridLibros.Location = new Point(26, 17);
            dataGridLibros.Name = "dataGridLibros";
            dataGridLibros.Size = new Size(736, 213);
            dataGridLibros.TabIndex = 0;
            // 
            // tabUsuarios
            // 
            tabUsuarios.Controls.Add(btnEliminarUsuario);
            tabUsuarios.Controls.Add(btnEditarUsuario);
            tabUsuarios.Controls.Add(btnAgregarUsuario);
            tabUsuarios.Controls.Add(dataGridUsuarios);
            tabUsuarios.Location = new Point(4, 24);
            tabUsuarios.Name = "tabUsuarios";
            tabUsuarios.Padding = new Padding(3);
            tabUsuarios.Size = new Size(768, 398);
            tabUsuarios.TabIndex = 1;
            tabUsuarios.Text = "Usuarios";
            tabUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.Location = new Point(452, 322);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(75, 23);
            btnEliminarUsuario.TabIndex = 3;
            btnEliminarUsuario.Text = "Eliminar";
            btnEliminarUsuario.UseVisualStyleBackColor = true;
            btnEliminarUsuario.Click += btnEliminarUsuario_Click;
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.Location = new Point(276, 322);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(75, 23);
            btnEditarUsuario.TabIndex = 2;
            btnEditarUsuario.Text = "Editar";
            btnEditarUsuario.UseVisualStyleBackColor = true;
            btnEditarUsuario.Click += btnEditarUsuario_Click;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.Location = new Point(98, 322);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(75, 23);
            btnAgregarUsuario.TabIndex = 1;
            btnAgregarUsuario.Text = "Agregar";
            btnAgregarUsuario.UseVisualStyleBackColor = true;
            btnAgregarUsuario.Click += btnAgregarUsuario_Click;
            // 
            // dataGridUsuarios
            // 
            dataGridUsuarios.Location = new Point(69, 22);
            dataGridUsuarios.Name = "dataGridUsuarios";
            dataGridUsuarios.Size = new Size(611, 243);
            dataGridUsuarios.TabIndex = 0;
            // 
            // tabPrestamos
            // 
            tabPrestamos.Controls.Add(label4);
            tabPrestamos.Controls.Add(label3);
            tabPrestamos.Controls.Add(label2);
            tabPrestamos.Controls.Add(label1);
            tabPrestamos.Controls.Add(numDias);
            tabPrestamos.Controls.Add(cboLibro);
            tabPrestamos.Controls.Add(cboUsuario);
            tabPrestamos.Controls.Add(btnDevolver);
            tabPrestamos.Controls.Add(btnPrestar);
            tabPrestamos.Controls.Add(dataGridPrestamos);
            tabPrestamos.Location = new Point(4, 24);
            tabPrestamos.Name = "tabPrestamos";
            tabPrestamos.Padding = new Padding(3);
            tabPrestamos.Size = new Size(768, 398);
            tabPrestamos.TabIndex = 2;
            tabPrestamos.Text = "Prestamos";
            tabPrestamos.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(360, 237);
            label4.Name = "label4";
            label4.Size = new Size(402, 15);
            label4.TabIndex = 9;
            label4.Text = "Para devolver un libro, seleccione  un prestamo de la lista y haga click aqui:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 325);
            label3.Name = "label3";
            label3.Size = new Size(160, 15);
            label3.TabIndex = 8;
            label3.Text = "Seleccione el numero de dias";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 281);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 7;
            label2.Text = "Seleccione un libro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 237);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 6;
            label1.Text = "Seleccione un usuario";
            // 
            // numDias
            // 
            numDias.Location = new Point(98, 347);
            numDias.Name = "numDias";
            numDias.Size = new Size(120, 23);
            numDias.TabIndex = 5;
            // 
            // cboLibro
            // 
            cboLibro.FormattingEnabled = true;
            cboLibro.Location = new Point(96, 299);
            cboLibro.Name = "cboLibro";
            cboLibro.Size = new Size(121, 23);
            cboLibro.TabIndex = 4;
            // 
            // cboUsuario
            // 
            cboUsuario.FormattingEnabled = true;
            cboUsuario.Location = new Point(96, 255);
            cboUsuario.Name = "cboUsuario";
            cboUsuario.Size = new Size(121, 23);
            cboUsuario.TabIndex = 3;
            // 
            // btnDevolver
            // 
            btnDevolver.Location = new Point(570, 273);
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Size = new Size(75, 23);
            btnDevolver.TabIndex = 2;
            btnDevolver.Text = "Devolver";
            btnDevolver.UseVisualStyleBackColor = true;
            btnDevolver.Click += btnDevolver_Click;
            // 
            // btnPrestar
            // 
            btnPrestar.Location = new Point(255, 347);
            btnPrestar.Name = "btnPrestar";
            btnPrestar.Size = new Size(75, 23);
            btnPrestar.TabIndex = 1;
            btnPrestar.Text = "Prestar";
            btnPrestar.UseVisualStyleBackColor = true;
            btnPrestar.Click += btnPrestar_Click;
            // 
            // dataGridPrestamos
            // 
            dataGridPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPrestamos.Location = new Point(96, 15);
            dataGridPrestamos.Name = "dataGridPrestamos";
            dataGridPrestamos.Size = new Size(569, 190);
            dataGridPrestamos.TabIndex = 0;
            // 
            // tabDashboard
            // 
            tabDashboard.Location = new Point(4, 24);
            tabDashboard.Name = "tabDashboard";
            tabDashboard.Padding = new Padding(3);
            tabDashboard.Size = new Size(768, 398);
            tabDashboard.TabIndex = 3;
            tabDashboard.Text = "Dashboard";
            tabDashboard.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "BibliotecaApp";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabLibros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridLibros).EndInit();
            tabUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridUsuarios).EndInit();
            tabPrestamos.ResumeLayout(false);
            tabPrestamos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridPrestamos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabLibros;
        private TabPage tabUsuarios;
        private TabPage tabPrestamos;
        private TabPage tabDashboard;
        private Button btnAgregar;
        private DataGridView dataGridLibros;
        private Button btnEliminar;
        private Button btnEditar;
        private DataGridView dataGridUsuarios;
        private Button btnEliminarUsuario;
        private Button btnEditarUsuario;
        private Button btnAgregarUsuario;
        private Button btnPrestar;
        private DataGridView dataGridPrestamos;
        private NumericUpDown numDias;
        private ComboBox cboLibro;
        private ComboBox cboUsuario;
        private Button btnDevolver;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}
