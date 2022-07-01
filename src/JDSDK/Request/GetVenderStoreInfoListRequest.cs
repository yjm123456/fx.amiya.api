using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class GetVenderStoreInfoListRequest : JdRequestBase<GetVenderStoreInfoListResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  exStoreId {get; set; }
                                                                                                                                                                                                                                 public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  storeId {get; set; }
                                                                                                                                                                                                public  		string
              storeName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              storeStatus
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              firstAddress
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              secondAddress
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              thirdAddress
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.getVenderStoreInfoList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("exStoreId", this.            exStoreId
);
                                                                                                                                                                                parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                parameters.Add("storeId", this.            storeId
);
                                                                                                                                parameters.Add("storeName", this.            storeName
);
                                                                                                        parameters.Add("storeStatus", this.            storeStatus
);
                                                                                                        parameters.Add("firstAddress", this.            firstAddress
);
                                                                                                        parameters.Add("secondAddress", this.            secondAddress
);
                                                                                                        parameters.Add("thirdAddress", this.            thirdAddress
);
                                                                            }
    }
}





        
 

