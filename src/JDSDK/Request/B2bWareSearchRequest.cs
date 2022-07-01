using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bWareSearchRequest : JdRequestBase<B2bWareSearchResponse>
    {
                                                                                                                                              public  		string
              channelType
 {get; set;}
                                                          
                                                                                                                                                                                        public  		Nullable<long>
              thirdCid
 {get; set;}
                                                          
                                                          public  		string
              skuSearchTypeEnum
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              laskSkuId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              brandId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.b2b.ware.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("channelType", this.            channelType
);
                                                                                                                                                                                                                        parameters.Add("thirdCid", this.            thirdCid
);
                                                                                                        parameters.Add("skuSearchTypeEnum", this.            skuSearchTypeEnum
);
                                                                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("laskSkuId", this.            laskSkuId
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("brandId", this.            brandId
);
                                                                            }
    }
}





        
 

