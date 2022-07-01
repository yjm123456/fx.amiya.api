using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bPoPoMidProviderQueryPurOrdersRequest : JdRequestBase<B2bPoPoMidProviderQueryPurOrdersResponse>
    {
                                                                                                                                                                               public  		string
              userName
 {get; set;}
                                                          
                                                          public  		string
              companyName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              issueInvoice
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              submitPoTimeFrom
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              submitPoTimeTo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              consProvinceId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              consCityId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              consCountyId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              consTownId
 {get; set;}
                                                          
                                                          public  		string
              consName
 {get; set;}
                                                          
                                                                                      public  		string
              thirdOrderIds
 {get; set;}
                                                          
                                                                                      public  		string
              thirdPoIds
 {get; set;}
                                                          
                                                                                      public  		string
              skuIndustryIds
 {get; set;}
                                                          
                                                                                      public  		string
              poValidStates
 {get; set;}
                                                          
                                                                                      public  		string
              pins
 {get; set;}
                                                          
                                                                                      public  		string
              sortTypes
 {get; set;}
                                                          
                                                                                      public  		string
              skuIndustryTypes
 {get; set;}
                                                          
                                                                                      public  		string
              popVenderIds
 {get; set;}
                                                          
                                                                                      public  		string
              paymentTypes
 {get; set;}
                                                          
                                                                                      public  		string
              poChannels
 {get; set;}
                                                          
                                                                                      public  		string
              poIds
 {get; set;}
                                                          
                                                                                      public  		string
              poTiers
 {get; set;}
                                                          
                                                                                      public  		string
              b2bVenderIds
 {get; set;}
                                                          
                                                                                      public  		string
              jdOrderIds
 {get; set;}
                                                          
                                                                                      public  		string
              skuIds
 {get; set;}
                                                          
                                                                                      public  		string
              poStatuses
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.b2b.po.PoMidProvider.queryPurOrders";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("userName", this.            userName
);
                                                                                                        parameters.Add("companyName", this.            companyName
);
                                                                                                        parameters.Add("issueInvoice", this.            issueInvoice
);
                                                                                                        parameters.Add("submitPoTimeFrom", this.            submitPoTimeFrom
);
                                                                                                        parameters.Add("submitPoTimeTo", this.            submitPoTimeTo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("consProvinceId", this.            consProvinceId
);
                                                                                                        parameters.Add("consCityId", this.            consCityId
);
                                                                                                        parameters.Add("consCountyId", this.            consCountyId
);
                                                                                                        parameters.Add("consTownId", this.            consTownId
);
                                                                                                        parameters.Add("consName", this.            consName
);
                                                                                                        parameters.Add("thirdOrderIds", this.            thirdOrderIds
);
                                                                                                        parameters.Add("thirdPoIds", this.            thirdPoIds
);
                                                                                                        parameters.Add("skuIndustryIds", this.            skuIndustryIds
);
                                                                                                        parameters.Add("poValidStates", this.            poValidStates
);
                                                                                                        parameters.Add("pins", this.            pins
);
                                                                                                        parameters.Add("sortTypes", this.            sortTypes
);
                                                                                                        parameters.Add("skuIndustryTypes", this.            skuIndustryTypes
);
                                                                                                        parameters.Add("popVenderIds", this.            popVenderIds
);
                                                                                                        parameters.Add("paymentTypes", this.            paymentTypes
);
                                                                                                        parameters.Add("poChannels", this.            poChannels
);
                                                                                                        parameters.Add("poIds", this.            poIds
);
                                                                                                        parameters.Add("poTiers", this.            poTiers
);
                                                                                                        parameters.Add("b2bVenderIds", this.            b2bVenderIds
);
                                                                                                        parameters.Add("jdOrderIds", this.            jdOrderIds
);
                                                                                                        parameters.Add("skuIds", this.            skuIds
);
                                                                                                        parameters.Add("poStatuses", this.            poStatuses
);
                                                                                                                            }
    }
}





        
 

