using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bWareQuerySkuToPoolRequest : JdRequestBase<B2bWareQuerySkuToPoolResponse>
    {
                                                                                                                                              public  		string
              businessChannel
 {get; set;}
                                                          
                                                                                                                                                                                        public  		string
              mappingId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              minJdSkuId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              jdSkuId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              totalItem
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              totalPage
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              mappingType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              b2bSkuToPoolQueryTypeEnum
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              b2bPoolId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.b2b.ware.querySkuToPool";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("businessChannel", this.            businessChannel
);
                                                                                                                                                                                                                        parameters.Add("mappingId", this.            mappingId
);
                                                                                                        parameters.Add("minJdSkuId", this.            minJdSkuId
);
                                                                                                        parameters.Add("jdSkuId", this.            jdSkuId
);
                                                                                                        parameters.Add("totalItem", this.            totalItem
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("totalPage", this.            totalPage
);
                                                                                                        parameters.Add("mappingType", this.            mappingType
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("b2bSkuToPoolQueryTypeEnum", this.            b2bSkuToPoolQueryTypeEnum
);
                                                                                                        parameters.Add("b2bPoolId", this.            b2bPoolId
);
                                                                            }
    }
}





        
 

