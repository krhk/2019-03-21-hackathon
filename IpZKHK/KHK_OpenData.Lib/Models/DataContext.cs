using KHK_OpenData.Lib.Entities;
using KHK_OpenData.Lib.EntitySets;
using KHK_OpenData.Lib.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace KHK_OpenData.Lib.Models
{
    public class DataContext
    {
        public IEntitySet<Architektura> ArchitekturaEntitySet { get; set; }
        public IEntitySet<AutobusovaZastavka> AutobusovaZastavkaEntitySet { get; set; }
        public IEntitySet<CirkevniPamatka> CirkevniPamatkaEntitySet { get; set; }
        public IEntitySet<Cyklostezky> CyklostezkyEntitySet { get; set; }
        public IEntitySet<Cyklovylet> CyklovyletEntitySet { get; set; }
        public IEntitySet<Divadlo> DivadloEntitySet { get; set; }
        //public IEntitySet<GastronomickaAkce> GastronomickaAkceEntitySet { get; set; }
        public IEntitySet<HistorickaPamatka> HistorickaPamatkaEntitySet { get; set; }
        public IEntitySet<Hrad> HradEntitySet { get; set; }
        public IEntitySet<InformacniCentrum> InformacniCentrumEntitySet { get; set; }
        public IEntitySet<Kino> KinoEntitySet { get; set; }
        public IEntitySet<Klub> KlubEntitySet { get; set; }
        public IEntitySet<Knihovna> KnihovnaEntitySet { get; set; }
        //public IEntitySet<KulturniAkce> KulturniAkceEntitySet { get; set; }
        public IEntitySet<Lanovka> LanovkaEntitySet { get; set; }
        public IEntitySet<LekarskaPohotovost> LekarskaPohotovostEntitySet { get; set; }
        public IEntitySet<Mesto> MestoEntitySet { get; set; }
        public IEntitySet<Muzeum> MuzeumEntitySet { get; set; }
        public IEntitySet<NaslednaPece> NaslednaPeceEntitySet { get; set; }
        public IEntitySet<NaucnaStezka> NaucnaStezkaEntitySet { get; set; }
        //public IEntitySet<OborySS> OborySSEntitySet { get; set; }
        public IEntitySet<PesiTuristika> PesiTuristikaEntitySet { get; set; }
        public IEntitySet<Pevnost> PevnostEntitySet { get; set; }
        public IEntitySet<PrirodniZajimavost> PrirodniZajimavostEntitySet { get; set; }
        //public IEntitySet<PrispevkovaOrganizace> PrispevkovaOrganizaceEntitySet { get; set; }
        public IEntitySet<Rozhledna> RozhlednaEntitySet { get; set; }
        //public IEntitySet<SportovniAkce> SportovniAkceEntitySet { get; set; }
        public IEntitySet<SocialniZarizeni> SocialniZarizeniEntitySet { get; set; }
        public IEntitySet<StomatologickaPohotovost> StomatologickaPohotovostEntitySet { get; set; }
        //public IEntitySet<TechnickaPamatka> TechnickaPamatkaEntitySet { get; set; }
        public IEntitySet<VekoveSlozeni> VekoveSlozeniEntitySet { get; set; }
        public IEntitySet<ZabavniCentrum> ZabavniCentrumEntitySet { get; set; }
        public IEntitySet<Zamek> ZamekEntitySet { get; set; }
        public IEntitySet<ZidovskaPamatka> ZidovskaPamatkaEntitySet { get; set; }
        public IEntitySet<PocetObyvatel> PocetObyvatelEntitySet { get; set; }

        private Thread refreshThread;

        private List<PropertyInfo> properties;
        private void Load(IConfiguration configuration)
        {
            string AssemblyName = Assembly.GetAssembly(this.GetType()).GetName().Name;
            foreach (ConfigurationSection section in configuration.GetChildren())
            {
                Type type = Type.GetType(AssemblyName + ".Entities." + section.Key);

                foreach (PropertyInfo property in properties)
                {
                    if (property.Name.Contains(section.Key))
                    {
                        Type entitySetType;
                        Type entitySet;
                        object value;
                        if (type.GetInterface(typeof(IXMLEntity).ToString()) != null)
                        {
                            entitySetType = typeof(XML<>);
                            entitySet = entitySetType.MakeGenericType(type);
                            value = Activator.CreateInstance(entitySet, new HttpDataProvider(new Uri(section.Value), Encoding.GetEncoding(1250)));
                        }
                        else if (type.GetInterface(typeof(IExcelEntity).ToString()) != null)
                        {
                            entitySetType = typeof(Excel<>);
                            entitySet = entitySetType.MakeGenericType(type);
                            value = Activator.CreateInstance(entitySet, new object[] { new HttpDataProvider(new Uri(section.Value), Encoding.GetEncoding(1250)), true });
                        }
                        else if (type.GetInterface(typeof(ICSVEntity).ToString()) != null)
                        {
                            entitySetType = typeof(CSV<>);
                            entitySet = entitySetType.MakeGenericType(type);
                            value = Activator.CreateInstance(entitySet, new object[] { new HttpDataProvider(new Uri(section.Value), Encoding.GetEncoding(1250)), true });
                        }
                        else
                        {
                            throw new Exception("Typ nemá implementaci");
                        }
                        property.SetValue(this, value);
                        break;
                    }
                }
            }
        }

        private void Reload()
        {
            foreach (PropertyInfo property in properties)
            {
                var iEntitySetValue = property.GetValue(this);
                var iEntitySet = iEntitySetValue.GetType();
                var iEntitySetType = typeof(IEntitySet<>);
                var iEntitySetGenType = iEntitySetType.MakeGenericType(iEntitySet.GetGenericArguments().First());
                if (iEntitySet.GetInterface(iEntitySetGenType.Name) != null)
                {
                    var method = iEntitySet.GetMethod("ToList");
                    var list = method.Invoke(iEntitySetValue, new object[] { });
                    iEntitySet.GetProperty("Entities").SetValue(iEntitySetValue, list);
                }
            }
        }

        public DataContext(IConfiguration configuration)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            properties = this.GetType().GetProperties().ToList();
            this.Load(configuration);
            refreshThread = new Thread(() => {
                while (true)
                {
                    Thread.Sleep(3600000);
                    this.Reload();
                }
            });
            refreshThread.Start();
        }

        public void ForEach(Action<object> func)
        {
            foreach (PropertyInfo property in properties)
            {
                var entityset = property.GetValue(this);
                var entitySetType = entityset.GetType();
                MethodInfo getList = entitySetType.GetMethod("GetList");

                if(getList != null)
                {
                    Type entitySetEntityType = entitySetType.GetGenericArguments().First();
                    Type listType = typeof(List<>).MakeGenericType(entitySetEntityType);
                    var list = listType.GetConstructor(new Type[] { }).Invoke(new object[] { });
                    list = getList.Invoke(entityset, null);
                    list?.GetType().GetMethod("ForEach").Invoke(list, new object[] { func });

                }
            }
        }
    }
}
