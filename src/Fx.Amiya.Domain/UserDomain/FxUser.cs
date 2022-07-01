using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Domain.UserDomain
{
   public class FxUser: IEntity
    {
        public string Id { get; private set; }

        public DateTime CreateDate { get; private set; }
        /// <summary>
        /// 用户是从公众号，小程序或者APP创建的信息
        /// </summary>
        public FxUserType CreateFromType { get; private set; }
        public bool Frozen { get; private set; }
        public bool Valid { get; private set; }

        public string CustomerId { get; set; }

        public FxUser(
              string id,
               DateTime createDate,

            FxUserType createFromType,
            string customerId = null,
            bool frozen = false,
            bool valid = true
            )
        {

            CreateDate = createDate;
            Id = id;
            Frozen = frozen;
            Valid = valid;
            CreateFromType = createFromType;
            CustomerId = customerId;
        }
    }
}
