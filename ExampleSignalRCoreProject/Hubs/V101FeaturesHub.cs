﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleSignalRCoreProject.Hubs
{
    public class V101FeaturesHub : Hub
    {
        public void UseContextConnIdTwice()
        {
            var x = Context.ConnectionId;
            var y = Context.ConnectionId;
        }

        public void AddUserToGroup()
        {
            Groups.AddToGroupAsync(Context.ConnectionId, "");
        }

        public void RemoveUserFromGroupByConnIdGroup()
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, "");
        }
    }
}