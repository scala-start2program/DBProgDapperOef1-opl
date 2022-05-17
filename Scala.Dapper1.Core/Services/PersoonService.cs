using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scala.Dapper1.Core.Entities;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Scala.Dapper1.Core.Services
{
    public class PersoonService
    {
        public List<Persoon> GetPersonen()
        {
            using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    List<Persoon> personen = connection.GetAll<Persoon>().ToList();
                    personen = personen.OrderBy(p => p.Naam).ThenBy(p=>p.Voornaam).ToList();
                    return personen;
                }
                catch
                {
                    return null;
                }
            }
        }
        public Persoon GetPersoon(string persoonId)
        {
            using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    return connection.Get<Persoon>(persoonId);
                }
                catch
                {
                    return null;
                }
            }
        }
        public bool AddPersoon(Persoon persoon)
        {
            using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    connection.Insert(persoon);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool UpdatePersoon(Persoon persoon)
        {
            using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    connection.Update(persoon);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool DeletePersoon(Persoon persoon)
        {
            using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    connection.Delete(persoon);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
