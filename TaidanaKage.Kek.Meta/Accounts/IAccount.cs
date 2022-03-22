using System;

namespace TaidanaKage.Kek.Meta
{
    /// <summary>
    /// Player Account
    /// </summary>
    public interface IAccount
    {

        string Name { get; }

        string Password { get; }

    }

}
