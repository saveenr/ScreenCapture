using System;
using System.Runtime.InteropServices;

namespace ScreenCaptureLib
{
    public class Atom: IDisposable
    {
        private static int auto_atom_name_count;
        private bool m_registered;
        private string atomname;
        
        private short m_atom_id;

        /// <summary>
        /// Creates a new Atom
        /// </summary>
        public Atom()
        {
            this.atomname = this.GetAutomaticAtomName();
            this.Register();
        }

        /// <summary>
        /// Creates a new Atom
        /// </summary>
        public Atom(string name)
        {
            if ( name==null)
            {
                throw new ArgumentNullException("name");
            }

            if (name.Length < 1 )
            {
                throw new ArgumentException("name");
            }

            this.atomname = name;
            this.Register();
        }

        public short AtomID
        {
            get
            {
                return this.m_atom_id;
            }
        }


        /// <summary>
        /// Returns the atom string
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get { return this.atomname; }
        }

        /// <summary>
        /// Registers the hotkey
        /// </summary>
        public void Register()
        {
            if (this.IsRegistered)
            {
                // already registered
                return;
            }

            if (this.atomname==null)
            {
                throw new Exception("atomname is numm");
            }


            short id = ScreenCaptureLib.Interop.Kernel32.GlobalAddAtom(this.atomname);
            if (id == 0)
            {
                throw new Exception("Unable to generate unique hotkey ID. Error: " + Marshal.GetLastWin32Error().ToString());
            }

            this.m_atom_id = id;

        }

        private string GetAutomaticAtomName()
        {
            string name = string.Format("{0}_{1}_{2}",
                                                      System.Threading.Thread.CurrentThread.ManagedThreadId.ToString("X8"),
                                                      System.Reflection.Assembly.GetCallingAssembly().FullName,
                                                      auto_atom_name_count);
            auto_atom_name_count++;
            return name;

            
        }

        /// <summary>
        /// Unregisters the hotkey
        /// </summary>
        public void Unregister()
        {

            if (!this.IsRegistered)
            {
                return;
            }


            // http://msdn.microsoft.com/en-us/library/ms649061(VS.85).aspx

            short atom = ScreenCaptureLib.Interop.Kernel32.GlobalDeleteAtom(this.m_atom_id);
            int last_error = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
            if (last_error != Interop.WinError.ERROR_SUCCESS)
            {
                // failed to delete atom
                throw new Exception("Failed to delete atom");

            }
            else
            {
                // successfully deleted atom
                this.m_registered= true;
                
            }

        }



        /// <summary>
        /// Will unregister the hotkey if needed
        /// </summary>
        public void Dispose()
        {
            this.Unregister();
        }


        /// <summary>
        /// Identifies whether the hotkey is current registered
        /// </summary>
        public bool IsRegistered
        {
            get
            {
                return this.m_registered;
            }
        }

    }
}