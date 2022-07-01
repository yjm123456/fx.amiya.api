using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsBatchOutBoundRequest : JdRequestBase<DropshipDpsBatchOutBoundResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                     		public  		string
  customOrderId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  memoByVendor {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  isJdexpress {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  parentOrderId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  addressId {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.dropship.dps.batchOutBound";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                parameters.Add("customOrderId", this.            customOrderId
);
                                                                                                        parameters.Add("memoByVendor", this.            memoByVendor
);
                                                                                                        parameters.Add("isJdexpress", this.            isJdexpress
);
                                                                                                        parameters.Add("parentOrderId", this.            parentOrderId
);
                                                                                                        parameters.Add("addressId", this.            addressId
);
                                                                                                    }
    }
}





        
 

