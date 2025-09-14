using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Diagnostics;

namespace BibliotecaApp
{
    public partial class MainForm : Form
    {
        // ===== MODELO =====
        public class Libro
        {
            public int Id { get; set; }              // autogenerado (no editable)
            public string Titulo { get; set; } = "";
            public string Autor { get; set; } = "";
            public int Anio { get; set; }
        }

        // ===== ESTADO =====
        private readonly BindingList<Libro> listaLibros = new BindingList<Libro>();
        private int nextId = 1;

        public MainForm()
        {
            InitializeComponent();

            loanService = new LoanService(listaLibros, listaUsuarios, listaPrestamos);

            // --- Top Libros ---
            chartTopBooks = new Chart { Name = "chartTopBooks", Size = new Size(420, 220), Location = new Point(16, 16) };
            chartTopBooks.ChartAreas.Add(new ChartArea("areaBooks"));
            tabDashboard.Controls.Add(chartTopBooks);

            // --- Top Usuarios ---
            chartTopUsers = new Chart { Name = "chartTopUsers", Size = new Size(420, 220), Location = new Point(456, 16) };
            chartTopUsers.ChartAreas.Add(new ChartArea("areaUsers"));
            tabDashboard.Controls.Add(chartTopUsers);

            // --- Serie mensual ---
            chartMonthly = new Chart { Name = "chartMonthly", Size = new Size(860, 240), Location = new Point(16, 252) };
            chartMonthly.ChartAreas.Add(new ChartArea("areaMonthly"));
            tabDashboard.Controls.Add(chartMonthly);
        }

        // ===== INICIALIZACION DE LA GRILLA =====
        private void Form1_Load(object? sender, EventArgs e)
        {
            dataGridLibros.DataSource = listaLibros;

            // Grilla solo lectura / seleccion por fila
            dataGridLibros.ReadOnly = true;
            dataGridLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridLibros.MultiSelect = false;
            dataGridLibros.AllowUserToAddRows = false;
            dataGridLibros.AllowUserToDeleteRows = false;
            dataGridLibros.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridLibros.RowHeadersVisible = false;

            UpdateButtonsState();

            // ===== GRILLA USUARIOS =====
            dataGridUsuarios.DataSource = listaUsuarios;
            dataGridUsuarios.ReadOnly = true;
            dataGridUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridUsuarios.MultiSelect = false;
            dataGridUsuarios.AllowUserToAddRows = false;
            dataGridUsuarios.AllowUserToDeleteRows = false;
            dataGridUsuarios.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridUsuarios.RowHeadersVisible = false;

            // habilitar/deshabilitar botones segun seleccion
            dataGridUsuarios.SelectionChanged += (_, __) =>
            {
                bool sel = dataGridUsuarios.CurrentRow?.DataBoundItem is Usuario;
                btnEditarUsuario.Enabled = sel;
                btnEliminarUsuario.Enabled = sel;
            };
            btnEditarUsuario.Enabled = false;
            btnEliminarUsuario.Enabled = false;

            // ===== PESTAÑA PRESTAMOS =====

            // Combos
            // USUARIOS
            cboUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUsuario.DisplayMember = "Nombre";   // lo que se muestra
            cboUsuario.ValueMember = "Id";        // el valor real
            cboUsuario.DataSource = listaUsuarios;   // BindingList<Usuario>

            // LIBROS
            cboLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLibro.DisplayMember = "Titulo";
            cboLibro.ValueMember = "Id";
            cboLibro.DataSource = listaLibros;      // BindingList<Libro>

            // Días por defecto
            numDias.Minimum = 1;
            numDias.Maximum = 60;
            numDias.Value = 14;

            // Grilla de prestamos
            dataGridPrestamos.AutoGenerateColumns = false;
            dataGridPrestamos.ReadOnly = true;
            dataGridPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridPrestamos.MultiSelect = false;
            dataGridPrestamos.AllowUserToAddRows = false;
            dataGridPrestamos.AllowUserToDeleteRows = false;
            dataGridPrestamos.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPrestamos.RowHeadersVisible = false;

            // Columnas
            dataGridPrestamos.Columns.Clear();
            dataGridPrestamos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID" });
            dataGridPrestamos.Columns.Add(new DataGridViewTextBoxColumn { Name = "UsuarioCol", HeaderText = "Usuario" });
            dataGridPrestamos.Columns.Add(new DataGridViewTextBoxColumn { Name = "LibroCol", HeaderText = "Libro" });
            dataGridPrestamos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaPrestamo", HeaderText = "Fecha préstamo" });
            dataGridPrestamos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaVencimiento", HeaderText = "Vence" });
            dataGridPrestamos.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Devuelto", HeaderText = "Devuelto" });
            dataGridPrestamos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaDevolucion", HeaderText = "Devolución" });

            // Rellenar columnas calculadas (Usuario/Libro)
            dataGridPrestamos.CellFormatting += dataGridPrestamos_CellFormatting;

            // Fuente de datos
            dataGridPrestamos.DataSource = listaPrestamos;

            // Habilitar/Deshabilitar boton Devolver segun seleccion
            dataGridPrestamos.SelectionChanged += (_, __) => UpdatePrestamoButtons();
            UpdatePrestamoButtons();

            RefreshDashboard();

            CargarDocumentacion();

        }

        private void UpdateButtonsState()
        {
            bool haySeleccion = dataGridLibros.CurrentRow?.DataBoundItem is Libro;
            btnEditar.Enabled = haySeleccion;
            btnEliminar.Enabled = haySeleccion;
        }

        // ===== CRUD =====
        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            using var dlg = new LibroForm();
            dlg.Text = "Agregar libro";
            dlg.Anio = DateTime.Now.Year;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                var libro = new Libro
                {
                    Id = nextId++,            // ID unico autogenerado
                    Titulo = dlg.Titulo,
                    Autor = dlg.Autor,
                    Anio = dlg.Anio
                };
                listaLibros.Add(libro);
                UpdateButtonsState();
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            if (dataGridLibros.CurrentRow?.DataBoundItem is not Libro seleccionado)
            {
                MessageBox.Show("Selecciona un libro primero.");
                return;
            }

            using var dlg = new LibroForm();
            dlg.Text = "Editar libro";
            dlg.Titulo = seleccionado.Titulo;
            dlg.Autor = seleccionado.Autor;
            dlg.Anio = seleccionado.Anio;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                seleccionado.Titulo = dlg.Titulo;
                seleccionado.Autor = dlg.Autor;
                seleccionado.Anio = dlg.Anio;
                dataGridLibros.Refresh();
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (dataGridLibros.CurrentRow?.DataBoundItem is not Libro seleccionado)
            {
                MessageBox.Show("Selecciona un libro primero.");
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Eliminar \"{seleccionado.Titulo}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                // Bloquearemos si hay prestamos activos
                listaLibros.Remove(seleccionado);
                UpdateButtonsState();
            }
        }
        // ===== USUARIOS: POO con herencia y polimorfismo =====
        public abstract class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = "";
            public string Email { get; set; } = "";
            public abstract decimal TarifaMoraDiaria { get; }  // polimorfica
            public string Tipo => GetType().Name;              // para mostrar en la grilla
        }
        public class Estudiante : Usuario
        {
            public override decimal TarifaMoraDiaria => 0.10m;
        }
        public class Personal : Usuario
        {
            public override decimal TarifaMoraDiaria => 0.05m;
        }

        // Estado de usuarios
        private readonly BindingList<Usuario> listaUsuarios = new BindingList<Usuario>();
        private int nextUserId = 1;

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            using var dlg = new UserForm();
            dlg.Text = "Agregar usuario";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Usuario u = dlg.Tipo == "Estudiante" ? new Estudiante() : new Personal();
                u.Id = nextUserId++;
                u.Nombre = dlg.Nombre;
                u.Email = dlg.Email;
                listaUsuarios.Add(u);
            }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridUsuarios.CurrentRow?.DataBoundItem is not Usuario uSel)
            { MessageBox.Show("Selecciona un usuario."); return; }

            using var dlg = new UserForm();
            dlg.Text = "Editar usuario";
            dlg.Nombre = uSel.Nombre;
            dlg.Email = uSel.Email;
            dlg.Tipo = (uSel is Estudiante) ? "Estudiante" : "Personal";

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                // permitir cambiar de tipo
                if ((dlg.Tipo == "Estudiante" && uSel is not Estudiante) ||
                    (dlg.Tipo == "Personal" && uSel is not Personal))
                {
                    // Reemplazar objeto conservando ID
                    Usuario nuevo = dlg.Tipo == "Estudiante" ? new Estudiante() : new Personal();
                    nuevo.Id = uSel.Id;
                    nuevo.Nombre = dlg.Nombre;
                    nuevo.Email = dlg.Email;

                    // sustituir en la lista
                    int idx = listaUsuarios.IndexOf(uSel);
                    listaUsuarios[idx] = nuevo;
                }
                else
                {
                    // mismo tipo: solo actualizar datos
                    uSel.Nombre = dlg.Nombre;
                    uSel.Email = dlg.Email;
                }
                dataGridUsuarios.Refresh();
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridUsuarios.CurrentRow?.DataBoundItem is not Usuario uSel)
            { MessageBox.Show("Selecciona un usuario."); return; }

            var confirm = MessageBox.Show($"¿Eliminar a \"{uSel.Nombre}\"?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                listaUsuarios.Remove(uSel);
            }
        }
        // ===== PRESTAMOS =====
        public class Loan
        {
            public int Id { get; set; }
            public int BookId { get; set; }
            public int UserId { get; set; }
            public DateTime FechaPrestamo { get; set; } = DateTime.Now;
            public DateTime FechaVencimiento { get; set; }
            public DateTime? FechaDevolucion { get; set; }

            public bool Devuelto => FechaDevolucion.HasValue;

            // Dias de atraso considerando hoy si aun no se ha devuelto
            public int DiasAtraso(DateTime? hoy = null)
            {
                var refDate = FechaDevolucion ?? (hoy ?? DateTime.Now);
                return Math.Max(0, (refDate.Date - FechaVencimiento.Date).Days);
            }
        }

        // Servicio que concentra la logica de prestar/devolver
        public class LoanService
        {
            private readonly BindingList<Libro> _libros;
            private readonly BindingList<Usuario> _usuarios;
            private readonly BindingList<Loan> _prestamos;
            private int _nextLoanId = 1;

            // Matriz para estadisticas: filas=mes (0..11), columnas=tipo (0=Estudiante,1=Personal)
            public int[,] PrestamosMesPorTipo { get; } = new int[12, 2];

            public LoanService(BindingList<Libro> libros,
                               BindingList<Usuario> usuarios,
                               BindingList<Loan> prestamos)
            {
                _libros = libros;
                _usuarios = usuarios;
                _prestamos = prestamos;
            }

            public Loan Lend(int bookId, int userId, int dias = 7)
            {
                var libro = _libros.FirstOrDefault(b => b.Id == bookId)
                    ?? throw new InvalidOperationException("Libro no existe.");
                var usuario = _usuarios.FirstOrDefault(u => u.Id == userId)
                    ?? throw new InvalidOperationException("Usuario no existe.");

                var loan = new Loan
                {
                    Id = _nextLoanId++,
                    BookId = libro.Id,
                    UserId = usuario.Id,
                    FechaPrestamo = DateTime.Now,
                    FechaVencimiento = DateTime.Now.AddDays(dias)
                };

                _prestamos.Add(loan);

                // Actualiza matriz mensual por tipo de usuario (para el dashboard)
                int m = DateTime.Now.Month - 1;
                int col = usuario is Estudiante ? 0 : 1;
                PrestamosMesPorTipo[m, col]++;

                return loan;
            }

            // Devuelve el libro y retorna la multa (si hay atraso)
            public decimal Return(int loanId, DateTime? fechaDevolucion = null)
            {
                var loan = _prestamos.FirstOrDefault(p => p.Id == loanId)
                    ?? throw new InvalidOperationException("Préstamo no existe.");

                if (loan.Devuelto) return 0m;

                loan.FechaDevolucion = fechaDevolucion ?? DateTime.Now;

                var usuario = _usuarios.First(u => u.Id == loan.UserId);
                int diasAtraso = loan.DiasAtraso();
                return diasAtraso * usuario.TarifaMoraDiaria;
            }

            // Helpers para dashboard (top N)
            public IEnumerable<(Libro libro, int count)> MostBorrowedBooks(int top = 5)
                => _prestamos.GroupBy(p => p.BookId)
                             .Select(g => (libro: _libros.First(b => b.Id == g.Key), count: g.Count()))
                             .OrderByDescending(x => x.count)
                             .Take(top);

            public IEnumerable<(Usuario usuario, int count)> MostActiveUsers(int top = 5)
                => _prestamos.GroupBy(p => p.UserId)
                             .Select(g => (usuario: _usuarios.First(u => u.Id == g.Key), count: g.Count()))
                             .OrderByDescending(x => x.count)
                             .Take(top);
        }
        // Lista de prestamos para bindear a la grilla
        private readonly BindingList<Loan> listaPrestamos = new BindingList<Loan>();

        // Servicio de prestamos (se inicializa en el constructor)
        private LoanService loanService;

        private void dataGridPrestamos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridPrestamos.Rows[e.RowIndex].DataBoundItem is not Loan loan) return;

            var colName = dataGridPrestamos.Columns[e.ColumnIndex].Name;
            if (colName == "UsuarioCol")
            {
                var u = listaUsuarios.FirstOrDefault(x => x.Id == loan.UserId);
                e.Value = u == null ? "(desconocido)" : $"{u.Id} - {u.Nombre} - {(u is Estudiante ? "Estudiante" : "Personal")}";
                e.FormattingApplied = true;
            }
            else if (colName == "LibroCol")
            {
                var b = listaLibros.FirstOrDefault(x => x.Id == loan.BookId);
                e.Value = b == null ? "(desconocido)" : $"{b.Id} - {b.Titulo}";
                e.FormattingApplied = true;
            }
        }
        private void UpdatePrestamoButtons()
        {
            if (dataGridPrestamos.CurrentRow?.DataBoundItem is Loan l)
                btnDevolver.Enabled = !l.Devuelto;
            else
                btnDevolver.Enabled = false;
        }
        private void RefreshDashboard()
        {
            // ================= TOP LIBROS =================
            chartTopBooks.Series.Clear();
            chartTopBooks.Legends.Clear();
            chartTopBooks.Titles.Clear();

            var topBooks = listaPrestamos
                .GroupBy(p => p.BookId)
                .Select(g => new
                {
                    Label = listaLibros.First(b => b.Id == g.Key).Titulo,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Label)
                .Take(5)
                .ToList();

            var sBooks = new Series("Préstamos")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32,
                IsValueShownAsLabel = true,
                IsXValueIndexed = true
            };
            chartTopBooks.Series.Add(sBooks);

            if (topBooks.Count > 0)
            {
                // Un solo bind, sin foreach y sin mezclar DataSource con AddXY
                sBooks.Points.DataBind(topBooks, "Label", "Count", null);
            }

            var areaBooks = chartTopBooks.ChartAreas["areaBooks"];
            areaBooks.AxisX.MajorGrid.Enabled = false;
            areaBooks.AxisY.MajorGrid.Enabled = false;
            areaBooks.AxisX.Interval = 1;
            areaBooks.AxisY.LabelStyle.Format = "0";
            areaBooks.AxisX.IsMarginVisible = true;   // evita recorte en extremos
            chartTopBooks.Titles.Add("Libros más Prestados");


            // ================= TOP USUARIOS =================
            chartTopUsers.Series.Clear();
            chartTopUsers.Legends.Clear();
            chartTopUsers.Titles.Clear();

            var topUsers = listaPrestamos
                .GroupBy(p => p.UserId)
                .Select(g => new
                {
                    Label = listaUsuarios.First(u => u.Id == g.Key).Nombre,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Label)
                .Take(5)
                .ToList();

            var sUsers = new Series("Préstamos")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32,
                IsValueShownAsLabel = true,
                IsXValueIndexed = true
            };
            chartTopUsers.Series.Add(sUsers);

            if (topUsers.Count > 0)
            {
                sUsers.Points.DataBind(topUsers, "Label", "Count", null);
            }

            var areaUsers = chartTopUsers.ChartAreas["areaUsers"];
            areaUsers.AxisX.MajorGrid.Enabled = false;
            areaUsers.AxisY.MajorGrid.Enabled = false;
            areaUsers.AxisX.Interval = 1;
            areaUsers.AxisY.LabelStyle.Format = "0";
            areaUsers.AxisX.IsMarginVisible = true;   // evita recorte
            chartTopUsers.Titles.Add("Usuarios más Activos");


            // ================= SERIE MENSUAL =================
            chartMonthly.Series.Clear();
            chartMonthly.Titles.Clear();

            var sEst = new Series("Estudiantes")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                IsValueShownAsLabel = true
            };
            var sPer = new Series("Personal")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                IsValueShownAsLabel = true
            };

            string[] meses = { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };
            for (int m = 0; m < 12; m++)
            {
                sEst.Points.AddXY(meses[m], loanService.PrestamosMesPorTipo[m, 0]);
                sPer.Points.AddXY(meses[m], loanService.PrestamosMesPorTipo[m, 1]);
            }

            chartMonthly.Series.Add(sEst);
            chartMonthly.Series.Add(sPer);

            var areaMonthly = chartMonthly.ChartAreas["areaMonthly"];
            areaMonthly.AxisX.MajorGrid.Enabled = false;
            areaMonthly.AxisY.MajorGrid.Enabled = true;
            areaMonthly.AxisX.Interval = 1;
            areaMonthly.AxisY.LabelStyle.Format = "0";
            areaMonthly.AxisX.IsMarginVisible = true; // evita recorte
            chartMonthly.Titles.Add("Préstamos por mes y tipo de usuario");
        }

        private void btnPrestar_Click(object sender, EventArgs e)
        {
            if (cboUsuario.SelectedValue is int userId && cboLibro.SelectedValue is int bookId)
            {
                var uItem = (Usuario)cboUsuario.SelectedItem;
                var bItem = (Libro)cboLibro.SelectedItem;

                // Registrar el prestamo
                loanService.Lend(bookId, userId, (int)numDias.Value);
                dataGridPrestamos.Refresh();
                UpdatePrestamoButtons();
                RefreshDashboard();

                // Mensaje personalizado
                MessageBox.Show(
                    $"El libro \"{bItem.Titulo}\" fue prestado correctamente a {uItem.Nombre}.",
                    "Préstamo registrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show("Selecciona un usuario y un libro válido.");
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dataGridPrestamos.CurrentRow?.DataBoundItem is not Loan l)
            { MessageBox.Show("Selecciona un préstamo."); return; }

            try
            {
                var multa = loanService.Return(l.Id);
                dataGridPrestamos.Refresh();
                UpdatePrestamoButtons();
                RefreshDashboard();

                if (multa > 0)
                    MessageBox.Show($"Devolución registrada.\nMulta por atraso: ${multa:F2}");
                else
                    MessageBox.Show("Devolución registrada. Sin multa.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al devolver", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Chart chartTopBooks, chartTopUsers, chartMonthly;
        private void CargarDocumentacion()
        {
            try
            {
                // Carpeta donde corre el .exe (bin/Debug o bin/Release)
                string baseDir = AppContext.BaseDirectory;

                string mdPath = Path.Combine(baseDir, "README.md");
                string txtPath = Path.Combine(baseDir, "DOCUMENTACION.txt");
                string pdfPath = Path.Combine(baseDir, "Documentacion.pdf");

                if (File.Exists(mdPath))
                {
                    // Nota: RichTextBox no renderiza Markdown, lo mostrara como texto plano
                    txtDocumentacion.Text = File.ReadAllText(mdPath);
                }
                else if (File.Exists(txtPath))
                {
                    txtDocumentacion.Text = File.ReadAllText(txtPath);
                }
                else if (File.Exists(pdfPath))
                {
                    txtDocumentacion.Text =
                        "Se encontró la documentación en PDF, pero este visor es de texto.\r\n" +
                        "Haga clic en el boton 'Abrir PDF' o abra el archivo:\r\n" +
                        pdfPath;
                }
                else
                {
                    txtDocumentacion.Text =
                        "No se encontró README.md, DOCUMENTACION.txt ni Documentacion.pdf\r\n";       
                }
            }
            catch (Exception ex)
            {
                txtDocumentacion.Text = "Error al cargar la documentación:\r\n" + ex.Message;
            }
        }
    }
}
