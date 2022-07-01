using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpMasterInsertCustomerRequest : JdRequestBase<EclpMasterInsertCustomerResponse>
    {
                                                                                                                                              public  		string
              sellerNo
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              customerNo
 {get; set;}
                                                          
                                                          public  		string
              customerName
 {get; set;}
                                                          
                                                          public  		string
              contacts
 {get; set;}
                                                          
                                                          public  		string
              phone
 {get; set;}
                                                          
                                                          public  		string
              customerEmail
 {get; set;}
                                                          
                                                          public  		string
              customerAddress
 {get; set;}
                                                          
                                                          public  		string
              customerType
 {get; set;}
                                                          
                                                          public  		string
              transitType
 {get; set;}
                                                          
                                                          public  		string
              warehouseName
 {get; set;}
                                                          
                                                          public  		string
              provinceName
 {get; set;}
                                                          
                                                          public  		string
              cityName
 {get; set;}
                                                          
                                                          public  		string
              countyName
 {get; set;}
                                                          
                                                          public  		string
              townName
 {get; set;}
                                                          
                                                          public  		string
              rection
 {get; set;}
                                                          
                                                          public  		string
              customerRemark
 {get; set;}
                                                          
                                                          public  		string
              licenseAddr
 {get; set;}
                                                          
                                                          public  		string
              licenseUnit
 {get; set;}
                                                          
                                                          public  		string
              licenseUnitNo
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
 {get; set;}
                                                          
                                                          public  		string
              sellerName
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.master.insertCustomer";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("sellerNo", this.            sellerNo
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("customerNo", this.            customerNo
);
                                                                                                        parameters.Add("customerName", this.            customerName
);
                                                                                                        parameters.Add("contacts", this.            contacts
);
                                                                                                        parameters.Add("phone", this.            phone
);
                                                                                                        parameters.Add("customerEmail", this.            customerEmail
);
                                                                                                        parameters.Add("customerAddress", this.            customerAddress
);
                                                                                                        parameters.Add("customerType", this.            customerType
);
                                                                                                        parameters.Add("transitType", this.            transitType
);
                                                                                                        parameters.Add("warehouseName", this.            warehouseName
);
                                                                                                        parameters.Add("provinceName", this.            provinceName
);
                                                                                                        parameters.Add("cityName", this.            cityName
);
                                                                                                        parameters.Add("countyName", this.            countyName
);
                                                                                                        parameters.Add("townName", this.            townName
);
                                                                                                        parameters.Add("rection", this.            rection
);
                                                                                                        parameters.Add("customerRemark", this.            customerRemark
);
                                                                                                        parameters.Add("licenseAddr", this.            licenseAddr
);
                                                                                                        parameters.Add("licenseUnit", this.            licenseUnit
);
                                                                                                        parameters.Add("licenseUnitNo", this.            licenseUnitNo
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
);
                                                                                                        parameters.Add("sellerName", this.            sellerName
);
                                                                                                                            }
    }
}





        
 

