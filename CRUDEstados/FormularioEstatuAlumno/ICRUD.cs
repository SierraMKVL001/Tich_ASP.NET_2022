using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormularioEstatuAlumno
{
    public interface ICRUD
    {
        List<EstatusAlumnos> Consultar();
        EstatusAlumnos Consultar(int id);
        int Agregar(EstatusAlumnos estatus);
        void Actualizar(EstatusAlumnos estatus);
        void Eliminar(int id);

    }
}
