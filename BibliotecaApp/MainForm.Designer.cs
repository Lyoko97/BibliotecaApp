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
            tabControl = new TabControl();
            tabLibros = new TabPage();
            labLibros1 = new Label();
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
            tabDocumentacion = new TabPage();
            txtDocumentacion = new RichTextBox();
            labLibros2 = new Label();
            labLibros3 = new Label();
            labUsuarios1 = new Label();
            labUsuarios2 = new Label();
            tabControl.SuspendLayout();
            tabLibros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridLibros).BeginInit();
            tabUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridUsuarios).BeginInit();
            tabPrestamos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridPrestamos).BeginInit();
            tabDocumentacion.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabLibros);
            tabControl.Controls.Add(tabUsuarios);
            tabControl.Controls.Add(tabPrestamos);
            tabControl.Controls.Add(tabDashboard);
            tabControl.Controls.Add(tabDocumentacion);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 426);
            tabControl.TabIndex = 0;
            // 
            // tabLibros
            // 
            tabLibros.Controls.Add(labLibros3);
            tabLibros.Controls.Add(labLibros2);
            tabLibros.Controls.Add(labLibros1);
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
            // labLibros1
            // 
            labLibros1.AutoSize = true;
            labLibros1.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labLibros1.Location = new Point(50, 23);
            labLibros1.Name = "labLibros1";
            labLibros1.Size = new Size(222, 21);
            labLibros1.TabIndex = 4;
            labLibros1.Text = "📚 Bienvenido a BibliotecaAPP";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(669, 351);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(569, 351);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(50, 351);
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
            dataGridLibros.Location = new Point(26, 87);
            dataGridLibros.Name = "dataGridLibros";
            dataGridLibros.Size = new Size(736, 213);
            dataGridLibros.TabIndex = 0;
            // 
            // tabUsuarios
            // 
            tabUsuarios.Controls.Add(labUsuarios2);
            tabUsuarios.Controls.Add(labUsuarios1);
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
            btnEliminarUsuario.Location = new Point(653, 336);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(75, 23);
            btnEliminarUsuario.TabIndex = 3;
            btnEliminarUsuario.Text = "Eliminar";
            btnEliminarUsuario.UseVisualStyleBackColor = true;
            btnEliminarUsuario.Click += btnEliminarUsuario_Click;
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.Location = new Point(561, 336);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(75, 23);
            btnEditarUsuario.TabIndex = 2;
            btnEditarUsuario.Text = "Editar";
            btnEditarUsuario.UseVisualStyleBackColor = true;
            btnEditarUsuario.Click += btnEditarUsuario_Click;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.Location = new Point(69, 336);
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
            // tabDocumentacion
            // 
            tabDocumentacion.Controls.Add(txtDocumentacion);
            tabDocumentacion.Location = new Point(4, 24);
            tabDocumentacion.Name = "tabDocumentacion";
            tabDocumentacion.Padding = new Padding(3);
            tabDocumentacion.Size = new Size(768, 398);
            tabDocumentacion.TabIndex = 4;
            tabDocumentacion.Text = "Documentacion";
            tabDocumentacion.UseVisualStyleBackColor = true;
            // 
            // txtDocumentacion
            // 
            txtDocumentacion.BorderStyle = BorderStyle.None;
            txtDocumentacion.Dock = DockStyle.Fill;
            txtDocumentacion.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDocumentacion.Location = new Point(3, 3);
            txtDocumentacion.Name = "txtDocumentacion";
            txtDocumentacion.ReadOnly = true;
            txtDocumentacion.Size = new Size(762, 392);
            txtDocumentacion.TabIndex = 0;
            txtDocumentacion.Text = "";
            // 
            // labLibros2
            // 
            labLibros2.AutoSize = true;
            labLibros2.ImageAlign = ContentAlignment.TopLeft;
            labLibros2.Location = new Point(50, 318);
            labLibros2.Name = "labLibros2";
            labLibros2.Size = new Size(132, 15);
            labLibros2.TabIndex = 5;
            labLibros2.Text = "Agregar un nuevo libro:";
            // 
            // labLibros3
            // 
            labLibros3.AutoSize = true;
            labLibros3.Location = new Point(543, 318);
            labLibros3.Name = "labLibros3";
            labLibros3.Size = new Size(204, 15);
            labLibros3.TabIndex = 6;
            labLibros3.Text = "Seleccione un libro y elija una accion:";
            // 
            // labUsuarios1
            // 
            labUsuarios1.AutoSize = true;
            labUsuarios1.Location = new Point(69, 293);
            labUsuarios1.Name = "labUsuarios1";
            labUsuarios1.Size = new Size(147, 15);
            labUsuarios1.TabIndex = 4;
            labUsuarios1.Text = "Agregar un nuevo usuario:";
            // 
            // labUsuarios2
            // 
            labUsuarios2.AutoSize = true;
            labUsuarios2.Location = new Point(534, 293);
            labUsuarios2.Name = "labUsuarios2";
            labUsuarios2.Size = new Size(219, 15);
            labUsuarios2.TabIndex = 5;
            labUsuarios2.Text = "Seleccione un usuario y elija una accion:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            Name = "MainForm";
            Text = "BibliotecaApp";
            Load += Form1_Load;
            tabControl.ResumeLayout(false);
            tabLibros.ResumeLayout(false);
            tabLibros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridLibros).EndInit();
            tabUsuarios.ResumeLayout(false);
            tabUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridUsuarios).EndInit();
            tabPrestamos.ResumeLayout(false);
            tabPrestamos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridPrestamos).EndInit();
            tabDocumentacion.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
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
        private TabPage tabDocumentacion;
        private RichTextBox txtDocumentacion;
        private Label labLibros1;
        private Label labLibros2;
        private Label labLibros3;
        private Label labUsuarios1;
        private Label labUsuarios2;
    }
}
