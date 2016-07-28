using Authentication;
using DistanceStudy.Forms.Admin;
using DistanceStudy.Forms.Teacher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DistanceStudy.Test
{
    [TestClass]
    public class AuthenticationTest
    {
        private Dictionary<string, Form> _dictionaryForms;
        [TestInitialize]
        public void Initialize()
        {
            _dictionaryForms = new Dictionary<string, Form>
            {
                {"teacher", new FormMainTeacher()},
                {"user", new Form()},
                {"admin", new FormAdminPanel()}
            };
        }

        [TestMethod]
        public void ServiceShouldReturnAdminForm()
        {
            AuthenticationModule module = new AuthenticationModule("admin", "123", _dictionaryForms);
            var usersForm = module.CreateUserForm();
            Assert.AreEqual(_dictionaryForms["admin"], usersForm);
        }

        [TestMethod]
        public void ServiceShouldReturnTeacherForm()
        {
            AuthenticationModule module = new AuthenticationModule("user", "123", _dictionaryForms);
            var usersForm = module.CreateUserForm();
            Assert.AreEqual(_dictionaryForms["teacher"], usersForm);
        }

        [TestMethod]
        public void ServiceShouldReturnUserForm()
        {
            AuthenticationModule module = new AuthenticationModule("teacher", "123", _dictionaryForms);
            var usersForm = module.CreateUserForm();
            Assert.AreEqual(_dictionaryForms["user"], usersForm);
        }
    }
}
