﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.CloudServices
{
    public interface IFileStorageService
    {
        void Upload(byte[] bytes, string fileName);
    }
}
