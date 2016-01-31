using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMVCLoginTest.Models
{
    /// <summary>
    /// Base class for User.
    /// </summary>
    public class User
    {
        #region Fields

        // The id field of the User class.
        private int id;

        // The name field of the User class.
        private string name;

        // The email field of the User class.
        private string email;

        // The registration date field of the User class.
        private DateTime registrationDate;

        // The is deleted field of the User class.
        private bool isDeleted;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Gets or sets the registrationDate.
        /// </summary>
        /// <value>
        /// The registrationDate.
        /// </value>
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }

        /// <summary>
        /// Gets or sets the isDeleted.
        /// </summary>
        /// <value>
        /// The isDeleted.
        /// </value>
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">The value for the id field.</param>
        /// <param name="name">The value for the name field.</param>
        /// <param name="email">The value for the email field.</param>
        /// <param name="registrationdate">The value for the registration date field.</param>
        /// <param name="isdeleted">The value for the is deleted field.</param>
        public User(int id, string name, string email, DateTime registrationdate, bool isdeleted)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.registrationDate = registrationdate;
            this.isDeleted = isdeleted;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Formats the registration date.
        /// </summary>
        /// <returns>The formated date as string or empty string.</returns>
        public string FormatRegistrationDate()
        {
            try
            {
                return registrationDate.ToString("yyyy-MM-dd hh:mm");
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion Methods
    }
}