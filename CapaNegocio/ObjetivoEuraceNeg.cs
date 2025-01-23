using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocio
{
    public class ObjetivoEuraceNeg
    {
        public ObjetivoEuraceDAL objetivoEuraceDAL = new ObjetivoEuraceDAL();

        public List<ObjetivoEurace> MostrarObjetivoEurace()
        {
            return objetivoEuraceDAL.MostrarObjetivoEurace();
        }

        public void InsertarObjetivoEurace(ObjetivoEurace objetivoEurace)
        {
            objetivoEuraceDAL.InsertarObjetivoEurace(objetivoEurace);
        }

        public void ActualizarObjetivoEurace(ObjetivoEurace objetivoEurace)
        {
            objetivoEuraceDAL.ActualizarObjetivoEurace(objetivoEurace);
        }

        public void EliminarObjetivoEurace(int idObjetivoEurace)
        {
            objetivoEuraceDAL.EliminarObjetivoEurace(idObjetivoEurace);
        }
    }
}
