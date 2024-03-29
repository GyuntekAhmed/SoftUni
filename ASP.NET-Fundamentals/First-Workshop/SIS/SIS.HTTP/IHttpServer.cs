﻿namespace SIS.HTTP
{
    public interface IHttpServer
    {
        Task StartAsync();

        Task ResetAsync();

        void Stop();
    }
}