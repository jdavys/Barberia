namespace Barberia.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("registro")]
    public partial class Registro
    {
        public int id { get; set; }

        public string barbero { get; set; }

        public string corte { get; set; }

        public string local { get; set; }

        public string precio { get; set; }

        public int cantidad { get; set; }

        public DateTime fecha { get; set; }

        public List<Registro> Listar()
        {
            var regs = new List<Registro>();
            try
            {
                using (var ctx = new TextContext())
                {
                    regs = ctx.registro.ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return regs;
        }

        public Registro Obtener(int id)
        {
            var reg = new Registro();
            try
            {
                using (var ctx = new TextContext())
                {
                    reg = ctx.registro.Where(x => x.id == id).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return reg;
        }

        public void Guardar(Registro reg)
        {
            try
            {
                using (var ctx = new TextContext())
                {
                    if (reg.id > 0)
                    {
                        ctx.Entry(reg).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(reg).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (var ctx = new TextContext())
                {
                    ctx.Entry(new Registro { id = id }).State = EntityState.Deleted;

                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
