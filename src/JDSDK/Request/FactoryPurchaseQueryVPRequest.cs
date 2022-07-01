using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class FactoryPurchaseQueryVPRequest : JdRequestBase<FactoryPurchaseQueryVPResponse>
    {
                                                                                                                                              public  		Nullable<long>
              factoryId
 {get; set;}
                                                          
                                                                                                                            public  		string
              personalKey
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              ptId
 {get; set;}
                                                          
                                                                                                                                                       public  		string
              vendorCode
 {get; set;}
                                                          
                                                          public  		string
              vendorName
 {get; set;}
                                                          
                                                          public  		string
              vendorNameAbbr
 {get; set;}
                                                          
                                                          public  		string
              code
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              categoryId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              parentCategoryId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              rootCategoryId
 {get; set;}
                                                          
                                                          public  		string
              skuId
 {get; set;}
                                                          
                                                          public  		string
              skuName
 {get; set;}
                                                          
                                                          public  		string
              purchaseMan
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              skuType
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              available
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              createdStart
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              createdEnd
 {get; set;}
                                                          
                                                          public  		string
              stockInVendor
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              modifiedStart
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              modifiedEnd
 {get; set;}
                                                          
                                                          public  		string
              pageIndex
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.factory.purchase.queryVP";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("factoryId", this.            factoryId
);
                                                                                                                                                                                                        parameters.Add("personalKey", this.            personalKey
);
                                                                                                        parameters.Add("ptId", this.            ptId
);
                                                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("vendorName", this.            vendorName
);
                                                                                                        parameters.Add("vendorNameAbbr", this.            vendorNameAbbr
);
                                                                                                        parameters.Add("code", this.            code
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("categoryId", this.            categoryId
);
                                                                                                        parameters.Add("parentCategoryId", this.            parentCategoryId
);
                                                                                                        parameters.Add("rootCategoryId", this.            rootCategoryId
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("skuName", this.            skuName
);
                                                                                                        parameters.Add("purchaseMan", this.            purchaseMan
);
                                                                                                        parameters.Add("skuType", this.            skuType
);
                                                                                                        parameters.Add("available", this.            available
);
                                                                                                        parameters.Add("createdStart", this.            createdStart
);
                                                                                                        parameters.Add("createdEnd", this.            createdEnd
);
                                                                                                        parameters.Add("stockInVendor", this.            stockInVendor
);
                                                                                                        parameters.Add("modifiedStart", this.            modifiedStart
);
                                                                                                        parameters.Add("modifiedEnd", this.            modifiedEnd
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

