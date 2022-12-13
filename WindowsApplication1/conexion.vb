'Option Explicit On
Imports System.Data
Imports System.Data.SqlClient

Module conexion1
    'Agrega la dirección de tu conexión similar a este:
    Public conexion As New SqlConnection("Data Source=DESKTOP-4FPC8J0\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=False;User ID=sa;Password=sqlserver;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
End Module
