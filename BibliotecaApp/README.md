# Gestión de Biblioteca (WinForms .NET 8)

Aplicación de escritorio desarrollada en **C# con Windows Forms** que permite administrar libros, usuarios y préstamos, además de visualizar estadísticas gráficas de uso.

## Funcionalidades principales
- **Administrar Libros**: añadir, editar y eliminar libros.
- **Administrar Usuarios**: registro de estudiantes y personal.
- **Préstamos**:
  - Registrar préstamos indicando usuario, libro y días.
  - Registrar devoluciones con cálculo automático de multas.
- **Dashboard**:
  - Libros más prestados.
  - Usuarios más activos.
  - Evolución mensual de préstamos por tipo de usuario.

## Capturas de pantalla
Las capturas completas del funcionamiento se encuentran en el documento PDF adjunto en el aula digital.

Interfaz:

- Pestaña **Libros** → CRUD de libros.  
- Pestaña **Usuarios** → gestión de estudiantes/personal.  
- Pestaña **Préstamos** → registrar y devolver libros.  
- Pestaña **Dashboard** → estadísticas con gráficos.

## Requisitos
- Windows 10/11  
- [.NET 8 SDK]
- Visual Studio 2022 (con soporte para WinForms)  
- Paquete `System.Windows.Forms.DataVisualization` (para los gráficos)

## Ejecución
1. Clonar el repositorio:
   ```bash
   git clone https://github.com/Lyoko97/BibliotecaApp.git