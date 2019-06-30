using HNomi.Entities;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HNomiTest
{
    public class MySqlDbFake
    {

        private DbContextOptions<HNomiContext> _options;

        public MySqlDbFake()
        {
            _options = GetDbContextOptions;
        }

        public HNomiContext GetDBContext()
        {
            var context = new HNomiContext(_options);

            context.Database.EnsureCreated();
            return context;
        }

        private DbContextOptions<HNomiContext> GetDbContextOptions
        {
            get
            {
                /*var connection = new MySqlConnection("DataSource=:memory");
                connection.Open();*/

                var options = new DbContextOptionsBuilder<HNomiContext>()
                                    .UseInMemoryDatabase(databaseName: "BBDDPruebas")
                                    .Options;

                return options;
            }
        }

    }
}
