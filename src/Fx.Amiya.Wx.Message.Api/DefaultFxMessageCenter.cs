using Fx.Amiya.IService;
using Fx.Infrastructure.Utils;
using Fx.Weixin.MP.Message.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Wx.Message.Api
{
    /// <summary>
    /// 默认消息中心
    /// 基于rabbitmq消息队列
    /// </summary>
    public class DefaultFxMessageCenter: IFxMessageCenter
    {
        private RabbitMqProducer _rabbitMqProducer;
      
        public DefaultFxMessageCenter(string hostName, int port, string userName, string password, string queueName)
        {
          
            _rabbitMqProducer = new RabbitMqProducer(hostName, port, userName, password, queueName);
        }

        public void Add(RequestMessageBase requestMessageBase)
        {
        

            _rabbitMqProducer.SendMessage(JsonConvert.SerializeObject(requestMessageBase));

        }

        public async Task AddAsync(RequestMessageBase requestMessageBase)
        {
           

            _rabbitMqProducer.SendMessage(JsonConvert.SerializeObject(requestMessageBase));

        }
    }
}
