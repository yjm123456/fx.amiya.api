﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ReconciliationDocuments
{
    public class ReconciliationDocumentsReturnBackPriceDto
    {
        public List<string> ReconciliationDocumentsIdList { get; set; }
        public DateTime ReturnBackDate { get; set; }
    }
}
