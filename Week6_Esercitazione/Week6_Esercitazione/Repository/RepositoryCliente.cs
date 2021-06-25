using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Esercitazione.Context;
using Week6_Esercitazione.Models;

namespace Week6_Esercitazione.Repository
{
    class RepositoryCliente : IRepositoryCliente
    {
        public Cliente Create(Cliente item)
        {
            using(var ctx=new AssicurazioneContext())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Cliente>(item).State = EntityState.Added;
                        ctx.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex + "\n");
                        return null;
                    }
                }
            }
            return item;
        }

        public bool Delete(string id)
        {
            Cliente cliente = null;
            bool check = false;
            using(var ctx=new AssicurazioneContext())
            {
                if(id!=null && id.Length != 0)
                {
                    cliente=ctx.Clienti.Find(id);
                }
            }
            using (var ctx = new AssicurazioneContext())
            {
                if (cliente != null)
                {
                    try
                    {
                        ctx.Entry<Cliente>(cliente).State = EntityState.Deleted;
                        ctx.SaveChanges();
                        check = true;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex + "\n");
                        return check;
                    }
                }
                return check;
            }
        }

        public ICollection<Cliente> GetAll()
        {
            using(var ctx= new AssicurazioneContext())
            {
                return ctx.Clienti.ToList();
            }
        }

        public Cliente GetById(string id)
        {
            using (var ctx = new AssicurazioneContext())
            {
                if (id != null && id.Length != 0)
                {
                    return ctx.Clienti.Find(id);
                }
                return null;
            }
        }

    }
}
