using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderNewProcessRequest : JdRequestBase<UeOrderNewProcessResponse>
    {
                                                                                                                                              public  		string
              county
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                                          public  		string
              deliverCompany
 {get; set;}
                                                          
                                                          public  		string
              deliverArriveDate
 {get; set;}
                                                          
                                                          public  		string
              province
 {get; set;}
                                                          
                                                          public  		string
              assessValue
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              town
 {get; set;}
                                                          
                                                          public  		string
              level
 {get; set;}
                                                          
                                                          public  		string
              newPartPrice
 {get; set;}
                                                          
                                                          public  		string
              newPartQty
 {get; set;}
                                                          
                                                          public  		string
              barcode2
 {get; set;}
                                                          
                                                          public  		string
              barcode1
 {get; set;}
                                                          
                                                          public  		string
              appointTimes
 {get; set;}
                                                          
                                                          public  		string
              engineerCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              partStat
 {get; set;}
                                                          
                                                          public  		string
              failureReason
 {get; set;}
                                                          
                                                          public  		string
              bookOperateDate
 {get; set;}
                                                          
                                                          public  		string
              oldPartQty
 {get; set;}
                                                          
                                                          public  		string
              uniqueId
 {get; set;}
                                                          
                                                          public  		string
              oldPartCode
 {get; set;}
                                                          
                                                          public  		string
              bookDate
 {get; set;}
                                                          
                                                          public  		string
              city
 {get; set;}
                                                          
                                                          public  		string
              deliverNo
 {get; set;}
                                                          
                                                          public  		string
              siteName
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                          public  		string
              contactMan
 {get; set;}
                                                          
                                                          public  		string
              failureName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              bookTimes
 {get; set;}
                                                          
                                                          public  		string
              engineerName
 {get; set;}
                                                          
                                                          public  		string
              pic1
 {get; set;}
                                                          
                                                          public  		string
              assessItem
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              siteMobile
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              processType
 {get; set;}
                                                          
                                                          public  		string
              pic2
 {get; set;}
                                                          
                                                          public  		string
              pic3
 {get; set;}
                                                          
                                                          public  		string
              engineerMobile
 {get; set;}
                                                          
                                                          public  		string
              dealRemark
 {get; set;}
                                                          
                                                          public  		string
              pic4
 {get; set;}
                                                          
                                                          public  		string
              fixMethod
 {get; set;}
                                                          
                                                          public  		string
              siteCode
 {get; set;}
                                                          
                                                          public  		string
              address
 {get; set;}
                                                          
                                                          public  		string
              newPartName
 {get; set;}
                                                          
                                                          public  		string
              oldPartName
 {get; set;}
                                                          
                                                          public  		string
              cancleReason
 {get; set;}
                                                          
                                                          public  		string
              createBy
 {get; set;}
                                                          
                                                          public  		string
              newPartCode
 {get; set;}
                                                          
                                                          public  		string
              appid
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              dealResult
 {get; set;}
                                                          
                                                          public  		string
              settleCode
 {get; set;}
                                                          
                                                          public  		string
              pid
 {get; set;}
                                                          
                                                          public  		string
              sitePhoto
 {get; set;}
                                                          
                                                          public  		string
              insuranceNo
 {get; set;}
                                                          
                                                          public  		string
              insurancePhoto
 {get; set;}
                                                          
                                                          public  		string
              engineerPhoto
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.new.process";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("county", this.            county
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("deliverCompany", this.            deliverCompany
);
                                                                                                        parameters.Add("deliverArriveDate", this.            deliverArriveDate
);
                                                                                                        parameters.Add("province", this.            province
);
                                                                                                        parameters.Add("assessValue", this.            assessValue
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("town", this.            town
);
                                                                                                        parameters.Add("level", this.            level
);
                                                                                                        parameters.Add("newPartPrice", this.            newPartPrice
);
                                                                                                        parameters.Add("newPartQty", this.            newPartQty
);
                                                                                                        parameters.Add("barcode2", this.            barcode2
);
                                                                                                        parameters.Add("barcode1", this.            barcode1
);
                                                                                                        parameters.Add("appointTimes", this.            appointTimes
);
                                                                                                        parameters.Add("engineerCode", this.            engineerCode
);
                                                                                                        parameters.Add("partStat", this.            partStat
);
                                                                                                        parameters.Add("failureReason", this.            failureReason
);
                                                                                                        parameters.Add("bookOperateDate", this.            bookOperateDate
);
                                                                                                        parameters.Add("oldPartQty", this.            oldPartQty
);
                                                                                                        parameters.Add("uniqueId", this.            uniqueId
);
                                                                                                        parameters.Add("oldPartCode", this.            oldPartCode
);
                                                                                                        parameters.Add("bookDate", this.            bookDate
);
                                                                                                        parameters.Add("city", this.            city
);
                                                                                                        parameters.Add("deliverNo", this.            deliverNo
);
                                                                                                        parameters.Add("siteName", this.            siteName
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("contactMan", this.            contactMan
);
                                                                                                        parameters.Add("failureName", this.            failureName
);
                                                                                                        parameters.Add("bookTimes", this.            bookTimes
);
                                                                                                        parameters.Add("engineerName", this.            engineerName
);
                                                                                                        parameters.Add("pic1", this.            pic1
);
                                                                                                        parameters.Add("assessItem", this.            assessItem
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("siteMobile", this.            siteMobile
);
                                                                                                        parameters.Add("processType", this.            processType
);
                                                                                                        parameters.Add("pic2", this.            pic2
);
                                                                                                        parameters.Add("pic3", this.            pic3
);
                                                                                                        parameters.Add("engineerMobile", this.            engineerMobile
);
                                                                                                        parameters.Add("dealRemark", this.            dealRemark
);
                                                                                                        parameters.Add("pic4", this.            pic4
);
                                                                                                        parameters.Add("fixMethod", this.            fixMethod
);
                                                                                                        parameters.Add("siteCode", this.            siteCode
);
                                                                                                        parameters.Add("address", this.            address
);
                                                                                                        parameters.Add("newPartName", this.            newPartName
);
                                                                                                        parameters.Add("oldPartName", this.            oldPartName
);
                                                                                                        parameters.Add("cancleReason", this.            cancleReason
);
                                                                                                        parameters.Add("createBy", this.            createBy
);
                                                                                                        parameters.Add("newPartCode", this.            newPartCode
);
                                                                                                        parameters.Add("appid", this.            appid
);
                                                                                                        parameters.Add("dealResult", this.            dealResult
);
                                                                                                        parameters.Add("settleCode", this.            settleCode
);
                                                                                                        parameters.Add("pid", this.            pid
);
                                                                                                        parameters.Add("sitePhoto", this.            sitePhoto
);
                                                                                                        parameters.Add("insuranceNo", this.            insuranceNo
);
                                                                                                        parameters.Add("insurancePhoto", this.            insurancePhoto
);
                                                                                                        parameters.Add("engineerPhoto", this.            engineerPhoto
);
                                                                            }
    }
}





        
 

