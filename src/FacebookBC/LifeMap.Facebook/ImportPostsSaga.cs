using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using Facebook;
using LifeMap.Analysis.Commands;
using NServiceBus;

namespace LifeMap.Facebook
{
    public class ImportPostsSaga : SagaBase<IMessage>
    {
        private readonly IFacebookApplication _facebookApplication;

        public ImportPostsSaga()
        {
        }

        public void HandleUserAuthenticated(Guid id, AccessToken accessToken, string code, IFacebookApplication facebookApplication)
        {
            var fb = new FacebookClient(facebookApplication);
            fb.AccessToken = accessToken;
            dynamic result = fb.Get("me/feed");
            foreach (var row in result.data)
            {
                dynamic r = row;
                var command = new LogThoughtCommand
                                  {
                                      Id = Guid.NewGuid(),
                                      Content = row.story,
                                      ThoughtId = Guid.NewGuid(),
                                      Time = DateTime.Parse(r.created_time)
                                  };
                base.Dispatch(command);
            }

        }
    }
}
