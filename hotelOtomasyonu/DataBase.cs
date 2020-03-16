using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace hotelOtomasyonu
{
   public class DataBase
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=HotelOtomasyonu;Integrated Security=True;MultipleActiveResultSets=True");
    }
}
