using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpRtwAddRtwOrderRequest : JdRequestBase<EclpRtwAddRtwOrderResponse>
    {
                                                                                                                                              public  		string
              eclpSoNo
 {get; set;}
                                                          
                                                          public  		string
              eclpRtwNo
 {get; set;}
                                                          
                                                          public  		string
              isvRtwNum
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
 {get; set;}
                                                          
                                                          public  		string
              logicParam
 {get; set;}
                                                          
                                                          public  		string
              reson
 {get; set;}
                                                          
                                                          public  		string
              orderType
 {get; set;}
                                                          
                                                          public  		string
              packageNo
 {get; set;}
                                                          
                                                          public  		string
              isvSoNo
 {get; set;}
                                                          
                                                          public  		string
              orderMark
 {get; set;}
                                                          
                                                          public  		string
              shipperName
 {get; set;}
                                                          
                                                          public  		string
              ownerNo
 {get; set;}
                                                          
                                                          public  		string
              orderInType
 {get; set;}
                                                          
                                                          public  		string
              receiveLevel
 {get; set;}
                                                          
                                                          public  		string
              sellerRemark
 {get; set;}
                                                          
                                                          public  		string
              salesMan
 {get; set;}
                                                          
                                                          public  		string
              salesBillingStaff
 {get; set;}
                                                          
                                                          public  		string
              drugElectronicSupervisionCode
 {get; set;}
                                                          
                                                          public  		string
              registerOrgNo
 {get; set;}
                                                          
                                                          public  		string
              registerOrgName
 {get; set;}
                                                          
                                                          public  		string
              customerName
 {get; set;}
                                                          
                                                          public  		string
              receivePriority
 {get; set;}
                                                          
                                                          public  		string
              sellerRtwType
 {get; set;}
                                                          
                                                          public  		string
              sellerRtwTypeName
 {get; set;}
                                                          
                                                          public  		string
              salesPlatformName
 {get; set;}
                                                          
                                                          public  		string
              spSoNo
 {get; set;}
                                                          
                                                          public  		string
              shopName
 {get; set;}
                                                          
                                                          public  		string
              workOrderNo
 {get; set;}
                                                          
                                                                                                                      public  		string
              senderName
 {get; set;}
                                                          
                                                          public  		string
              senderTelPhone
 {get; set;}
                                                          
                                                          public  		string
              senderMobilePhone
 {get; set;}
                                                          
                                                                                           public  		string
              customerId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  isvGoodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  planQty {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  goodsLevel {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  productionDate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  packageBatchNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  eclpOutOrderNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  sellerOutOrderNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  unitPrice {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  money {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  mediumPackage {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  bigPackage {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  orderLine {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  batAttrListJson {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  deptGoodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  planRtwReasonNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  planRtwReasonDesc {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.eclp.rtw.addRtwOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("eclpSoNo", this.            eclpSoNo
);
                                                                                                        parameters.Add("eclpRtwNo", this.            eclpRtwNo
);
                                                                                                        parameters.Add("isvRtwNum", this.            isvRtwNum
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
);
                                                                                                        parameters.Add("logicParam", this.            logicParam
);
                                                                                                        parameters.Add("reson", this.            reson
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("packageNo", this.            packageNo
);
                                                                                                        parameters.Add("isvSoNo", this.            isvSoNo
);
                                                                                                        parameters.Add("orderMark", this.            orderMark
);
                                                                                                        parameters.Add("shipperName", this.            shipperName
);
                                                                                                        parameters.Add("ownerNo", this.            ownerNo
);
                                                                                                        parameters.Add("orderInType", this.            orderInType
);
                                                                                                        parameters.Add("receiveLevel", this.            receiveLevel
);
                                                                                                        parameters.Add("sellerRemark", this.            sellerRemark
);
                                                                                                        parameters.Add("salesMan", this.            salesMan
);
                                                                                                        parameters.Add("salesBillingStaff", this.            salesBillingStaff
);
                                                                                                        parameters.Add("drugElectronicSupervisionCode", this.            drugElectronicSupervisionCode
);
                                                                                                        parameters.Add("registerOrgNo", this.            registerOrgNo
);
                                                                                                        parameters.Add("registerOrgName", this.            registerOrgName
);
                                                                                                        parameters.Add("customerName", this.            customerName
);
                                                                                                        parameters.Add("receivePriority", this.            receivePriority
);
                                                                                                        parameters.Add("sellerRtwType", this.            sellerRtwType
);
                                                                                                        parameters.Add("sellerRtwTypeName", this.            sellerRtwTypeName
);
                                                                                                        parameters.Add("salesPlatformName", this.            salesPlatformName
);
                                                                                                        parameters.Add("spSoNo", this.            spSoNo
);
                                                                                                        parameters.Add("shopName", this.            shopName
);
                                                                                                        parameters.Add("workOrderNo", this.            workOrderNo
);
                                                                                                                                                parameters.Add("senderName", this.            senderName
);
                                                                                                        parameters.Add("senderTelPhone", this.            senderTelPhone
);
                                                                                                        parameters.Add("senderMobilePhone", this.            senderMobilePhone
);
                                                                                                                                parameters.Add("customerId", this.            customerId
);
                                                                                                                                                                                                                parameters.Add("isvGoodsNo", this.            isvGoodsNo
);
                                                                                                        parameters.Add("planQty", this.            planQty
);
                                                                                                        parameters.Add("goodsLevel", this.            goodsLevel
);
                                                                                                        parameters.Add("productionDate", this.            productionDate
);
                                                                                                        parameters.Add("packageBatchNo", this.            packageBatchNo
);
                                                                                                        parameters.Add("eclpOutOrderNo", this.            eclpOutOrderNo
);
                                                                                                        parameters.Add("sellerOutOrderNo", this.            sellerOutOrderNo
);
                                                                                                        parameters.Add("unitPrice", this.            unitPrice
);
                                                                                                        parameters.Add("money", this.            money
);
                                                                                                        parameters.Add("mediumPackage", this.            mediumPackage
);
                                                                                                        parameters.Add("bigPackage", this.            bigPackage
);
                                                                                                        parameters.Add("orderLine", this.            orderLine
);
                                                                                                        parameters.Add("batAttrListJson", this.            batAttrListJson
);
                                                                                                        parameters.Add("deptGoodsNo", this.            deptGoodsNo
);
                                                                                                        parameters.Add("planRtwReasonNo", this.            planRtwReasonNo
);
                                                                                                        parameters.Add("planRtwReasonDesc", this.            planRtwReasonDesc
);
                                                                                                                                                    }
    }
}





        
 

