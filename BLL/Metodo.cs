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
    }
}
