﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IRAO.Domain.Interfaces.Core
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
