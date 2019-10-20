using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Metodo
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static List<PagoDetalle> APago()
        {
            Expression<Func<PagoDetalle, bool>> filtro = p => true;
            RepositorioBase<PagoDetalle> repositorio = new RepositorioBase<PagoDetalle>();
            List<PagoDetalle> list = new List<PagoDetalle>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Analisis> Analisis()
        {
            Expression<Func<Analisis, bool>> filtro = p => true;
            RepositorioBase<Analisis> repositorio = new RepositorioBase<Analisis>();
            List<Analisis> list = new List<Analisis>();

            list = repositorio.GetList(filtro);

            return list;
        }
        public static List<TipoAnalisis> TipoAnalisis()
        {
            Expression<Func<TipoAnalisis, bool>> filtro = p => true;
            RepositorioBase<TipoAnalisis> repositorio = new RepositorioBase<TipoAnalisis>();
            List<TipoAnalisis> list = new List<TipoAnalisis>();

            list = repositorio.GetList(filtro);

            return list;
        }
    }
}
