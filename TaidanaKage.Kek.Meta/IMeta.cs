using TaidanaKage.Kek.Meta.Accounts;
using TaidanaKage.Kek.Meta.Clients;
using TaidanaKage.Kek.Meta.Rulesets;
using TaidanaKage.Kek.Meta.Worlds;

namespace TaidanaKage.Kek.Meta
{
    /// <summary>
    /// Meta.
    /// </summary>
    public interface IMeta
    {
        /// <summary>
        /// Full path to the Meta Folder.
        /// <br/>
        /// <example>
        /// For example:
        /// "C:\Users\User\AppData\Local\Taidana Kage\KeK"
        /// </example>
        /// </summary>
        public string Folder { get; }

        /// <summary>
        /// Full path to the Meta Database file.
        /// <br/>
        /// <example>
        /// For example:
        /// "C:\Users\User\AppData\Local\Taidana Kage\KeK\meta.db"
        /// </example>
        /// </summary>
        public string DatabaseFile { get; }

        /// <summary>
        /// Account Manager.
        /// </summary>
        public IAccountManager AccountManager { get; }

        /// <summary>
        /// Client Manager.
        /// </summary>
        public IClientManager ClientManager { get; }

        /// <summary>
        /// Ruleset Manager.
        /// </summary>
        public IRulesetManager RulesetManager { get; }

        /// <summary>
        /// World Manager.
        /// </summary>
        public IWorldManager WorldManager { get; }

        /// <summary>
        /// Loads the whole Meta Database into RAM (for faster access).
        /// </summary>
        public void LoadToMemory();

        /// <summary>
        /// Saves the whole Meta Database to the file on disk (to preserve all the changes).
        /// </summary>
        public void SaveToDisk();
    }
}