using BibliotecaClases_BD;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

public class FacturaCabecera
{
    // Atributos privados
    private int _idFactura;
    private string _numeroFactura;
    private DateTime _fecha;
    private int _idCliente;
    private int _idEmpresa;
    private int _idFormaPago;
    private string _tipoFactura;
    private string _cae;
    private DateTime _fechaVencimientoCAE;
    private decimal _subTotal;
    private decimal _iva;
    private decimal _total;
    private string _observaciones;

    // Propiedades públicas
    public int IdFactura { get => _idFactura; set => _idFactura = value; }
    public string NumeroFactura { get => _numeroFactura; set => _numeroFactura = value; }
    public DateTime Fecha { get => _fecha; set => _fecha = value; }
    public int IdCliente { get => _idCliente; set => _idCliente = value; }
    public int IdEmpresa { get => _idEmpresa; set => _idEmpresa = value; }
    public int IdFormaPago { get => _idFormaPago; set => _idFormaPago = value; }
    public string TipoFactura { get => _tipoFactura; set => _tipoFactura = value; }
    public string CAE { get => _cae; set => _cae = value; }
    public DateTime FechaVencimientoCAE { get => _fechaVencimientoCAE; set => _fechaVencimientoCAE = value; }
    public decimal SubTotal { get => _subTotal; set => _subTotal = value; }
    public decimal Iva { get => _iva; set => _iva = value; }
    public decimal Total { get => _total; set => _total = value; }
    public string Observaciones { get => _observaciones; set => _observaciones = value; }

    // Método para insertar en la base de datos
    public void InsertarFacturaCabecera()
    {
        try
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = @"INSERT INTO FacturaCabecera 
                                 (NumeroFactura, Fecha, IdCliente, IdEmpresa, IdFormaPago, TipoFactura, CAE, FechaVencimientoCAE, SubTotal, Iva, Total, Observaciones) 
                                 VALUES (@NumeroFactura, @Fecha, @IdCliente, @IdEmpresa, @IdFormaPago, @TipoFactura, @CAE, @FechaVencimientoCAE, @SubTotal, @Iva, @Total, @Observaciones)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NumeroFactura", NumeroFactura);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                    cmd.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);
                    cmd.Parameters.AddWithValue("@IdFormaPago", IdFormaPago);
                    cmd.Parameters.AddWithValue("@TipoFactura", TipoFactura);
                    cmd.Parameters.AddWithValue("@CAE", CAE);
                    cmd.Parameters.AddWithValue("@FechaVencimientoCAE", FechaVencimientoCAE);
                    cmd.Parameters.AddWithValue("@SubTotal", SubTotal);
                    cmd.Parameters.AddWithValue("@Iva", Iva);
                    cmd.Parameters.AddWithValue("@Total", Total);
                    cmd.Parameters.AddWithValue("@Observaciones", Observaciones ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al insertar la cabecera de la factura: " + ex.Message);
        }
    }

    public decimal CalcularTotalFactura(DataGridView dtgGrilla)
    {
        decimal totalFactura = 0;

        foreach (DataGridViewRow row in dtgGrilla.Rows)
        {
            if (row.Cells["Total"].Value != null)
            {
                totalFactura += Convert.ToDecimal(row.Cells["Total"].Value.ToString().Replace("$", ""));
            }
        }

        return totalFactura;
    }

    public int ObtenerIdFacturaCabecera()
    {
        int nuevoIdFactura = 1;

        string query = "SELECT ISNULL(MAX(IdFactura), 0) FROM FacturaCabecera";

        using (SqlConnection conn = Conexion.ObtenerConexion())
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                nuevoIdFactura = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el ID de factura: " + ex.Message);
            }
        }

        return nuevoIdFactura;
    }

    // Método para generar el número de factura y retornarlo
    public string GenerarNumeroFactura(int puntoVenta)
    {
        Random random = new Random();
        int numeroAleatorio = random.Next(1, 99999999);
        NumeroFactura = $"{puntoVenta.ToString("00000")}-{numeroAleatorio.ToString("00000000")}";
        return NumeroFactura;  // Retorna el número de factura generado
    }

    // Método para generar y retornar el CAE
    public string GenerarCAE()
    {
        Random random = new Random();
        string cae = "";
        for (int i = 0; i < 14; i++)
        {
            cae += random.Next(0, 9).ToString();
        }
        CAE = cae;
        return CAE;  // Retorna el CAE generado
    }

    // Método para generar y retornar la fecha de vencimiento del CAE
    public DateTime GenerarFechaVencimientoCAE()
    {
        FechaVencimientoCAE = Fecha.AddDays(15);
        return FechaVencimientoCAE;  // Retorna la fecha de vencimiento del CAE
    }

    // Sobrescribir el método ToString para mostrar el número y la fecha en el ComboBox
    public override string ToString()
    {
        return $"Factura N° {NumeroFactura} - {Fecha.ToShortDateString()}";
    }
}
