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
    class RepositoryPolizza:IRepositoryPolizza
    {
        public Polizza Create(Polizza item)
        {
            using (var ctx = new AssicurazioneContext())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Polizza>(item).State = EntityState.Added;
                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
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
            Polizza polizza = null;
            bool check = false;
            using (var ctx = new AssicurazioneContext())
            {
                if (id != null && id.Length != 0)
                {
                    polizza = ctx.Polizze.Find(id);
                }
            }
            using (var ctx = new AssicurazioneContext())
            {
                if (polizza != null)
                {
                    try
                    {
                        ctx.Entry<Polizza>(polizza).State = EntityState.Deleted;
                        ctx.SaveChanges();
                        check = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex + "\n");
                        return check;
                    }
                }
                return check;
            }
        }

        public ICollection<Polizza> GetAll()
        {
            using (var ctx = new AssicurazioneContext())
            {
                return ctx.Polizze.ToList();
            }
        }

        public Polizza GetById(string id)
        {
            using (var ctx = new AssicurazioneContext())
            {
                if (id != null && id.Length != 0)
                {
                    return ctx.Polizze.Find(id);
                }
                return null;
            }
        }
    }
}
