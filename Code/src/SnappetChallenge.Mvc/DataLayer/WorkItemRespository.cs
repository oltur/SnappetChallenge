﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using SnappetChallenge.Mvc.Models;

namespace SnappetChallenge.Mvc.DataLayer
{
    public class WorkItemRespository : IWorkItemRespository
    {
        public WorkItemRespository()
        {
        }

        public async Task<IList<WorkItem>> GetAll(Uri uri)
        {
            var wc = new WebClient();
            wc.Encoding = Encoding.GetEncoding(1252);
            var data = await wc.DownloadStringTaskAsync(uri);

            var csv = new CsvReader(new StringReader(data));
            var records = csv.GetRecords<WorkItem>();

            // Does not work - Json file is already corrupt
            // JsonConvert.DeserializeObject<WorkItem[]>(data);

            return records.ToList();
        }

    }
}
