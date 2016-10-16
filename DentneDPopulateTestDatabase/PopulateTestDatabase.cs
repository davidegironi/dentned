#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Model;
using DG.DentneD.Model.Entity;
using DG.DentneD.Model.Repositories;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace DG.DentneD.Test
{
    public class PopulateTestDatabase
    {
        private DentneDModel _dentnedModel = null;
        private string _connectionString = null;
        private Random _r = new Random();

        private readonly string _patientsDatadir = null;
        private readonly string _patientsAttachmentsdir = null;
        private readonly int _patientsNum = 0;

        public PopulateTestDatabase()
        {
            _dentnedModel = new DentneDModel();
            using (var context = (DbContext)Activator.CreateInstance(_dentnedModel.ContextType, _dentnedModel.ContextParameters))
            {
                _connectionString = context.Database.Connection.ConnectionString.ToString();
            }

            _patientsDatadir = ConfigurationManager.AppSettings["patientsDatadir"];
            _patientsAttachmentsdir = ConfigurationManager.AppSettings["patientsAttachmentsdir"];
            _patientsNum = Convert.ToInt16(ConfigurationManager.AppSettings["patientsNum"]);
        }

        public void Empty()
        {
            using (SqlConnection sourceSqlConnection = new SqlConnection())
            {
                sourceSqlConnection.ConnectionString = _connectionString;
                sourceSqlConnection.Open();

                //perform delete over all tables, exept reports
                Console.WriteLine("Empty all tables...");
                using (SqlCommand cmd = new SqlCommand(@"
EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'; DECLARE @sql NVARCHAR(max)=''; SELECT @sql += 'DELETE FROM [' + name + ']; ' FROM sys.Tables WHERE name NOT IN ('reports'); EXEC sp_executesql @sql; EXEC sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all;'"
                  , sourceSqlConnection))
                {
                    cmd.ExecuteNonQuery();
                }

                //reseed all tables, reseed reports counting records
                Console.WriteLine("Reseed all tables...");
                using (SqlCommand cmd = new SqlCommand(@"
EXEC sp_msforeachtable 'DBCC CHECKIDENT(''?'', RESEED, 0)'; DECLARE @max int; SELECT @max = MAX(reports_id) from reports; DBCC CHECKIDENT('reports', RESEED, @max);"
                    , sourceSqlConnection))
                {
                    cmd.ExecuteNonQuery();
                }

                try
                {
                    Directory.Delete(_patientsDatadir, true);
                    Directory.CreateDirectory(_patientsDatadir);
                }
                catch { }

                try
                {
                    Directory.Delete(_patientsAttachmentsdir, true);
                    Directory.CreateDirectory(_patientsAttachmentsdir);
                }
                catch { }

                sourceSqlConnection.Close();
            }
        }

        public void Populate()
        {
            int medicalrecordstypesNum = 10;
            int roomsNum = 3;
            int patientsattachmentstypesNum = 3;
            int treatmentstypesNum = 3;
            int treatmentspriceslistsNum = 2;
            int treatmentsNum = 100;
            bool generatedatafiles = true;

            Console.WriteLine("Add AddressesTypes...");
            addressestypes addressestypesHome = new addressestypes()
            {
                addressestypes_name = "Home"
            };
            _dentnedModel.AddressesTypes.Add(addressestypesHome);

            Console.WriteLine("Add ContactsTypes...");
            contactstypes contactstypesEMail = new contactstypes()
            {
                contactstypes_name = ContactsTypesRepository.SystemAttributes.EMail.ToString(),
            };
            _dentnedModel.ContactsTypes.Add(contactstypesEMail);
            contactstypes contactstypesMobile = new contactstypes()
            {
                contactstypes_name = "Telephone"
            };
            _dentnedModel.ContactsTypes.Add(contactstypesMobile);

            Console.WriteLine("Add MedicalrecordsTypes...");
            medicalrecordstypes[] medicalrecordstypes = new medicalrecordstypes[] { };
            for (int i = 0; i < medicalrecordstypesNum; i++)
            {
                medicalrecordstypes medicalrecordstypestmp = new medicalrecordstypes()
                {
                    medicalrecordstypes_name = "MedicalrecordsT " + (i + 1),
                };
                _dentnedModel.MedicalrecordsTypes.Add(medicalrecordstypestmp);
                medicalrecordstypes = medicalrecordstypes.Concat(new medicalrecordstypes[] { medicalrecordstypestmp }).ToArray();
            }

            Console.WriteLine("Add Taxes...");
            taxes taxesT22 = new taxes()
            {
                taxes_name = "Tax 22%",
                taxes_rate = 22
            };
            _dentnedModel.Taxes.Add(taxesT22);
            taxes taxesT04 = new taxes()
            {
                taxes_name = "Tax 4%",
                taxes_rate = 4
            };
            _dentnedModel.Taxes.Add(taxesT04);

            Console.WriteLine("Add TaxesDeductions...");
            taxesdeductions taxesdeductionsTD1 = new taxesdeductions()
            {
                taxesdeductions_name = "Ded Tax 01",
                taxesdeductions_rate = 20
            };
            _dentnedModel.TaxesDeductions.Add(taxesdeductionsTD1);

            Console.WriteLine("Add ComputedLines...");
            _dentnedModel.ComputedLines.Add(new computedlines()
            {
                computedlines_code = "DS1",
                computedlines_name = "Discount 01",
                taxes_id = taxesT22.taxes_id,
                computedlines_rate = -10
            });
            _dentnedModel.ComputedLines.Add(new computedlines()
            {
                computedlines_code = "AD1",
                computedlines_name = "Addition 01",
                taxes_id = taxesT22.taxes_id,
                computedlines_rate = 20
            });

            Console.WriteLine("Add Doctors...");
            doctors doctorsTest = new doctors()
            {
                doctors_name = "John",
                doctors_surname = "Doe",
                doctors_doctext = "Dr. John Doe\r\n123 Main Street\r\nTown, CA\r\nVAT 0123456789",
                doctors_username = "12345678",
                doctors_password = "123456"
            };
            _dentnedModel.Doctors.Add(doctorsTest);

            Console.WriteLine("Add Rooms...");
            rooms[] rooms = new rooms[] { };
            for (int i = 0; i < roomsNum; i++)
            {
                rooms roomstmp = new rooms()
                {
                    rooms_name = "Room " + (i + 1),
                };
                _dentnedModel.Rooms.Add(roomstmp);
                rooms = rooms.Concat(new rooms[] { roomstmp }).ToArray();
            }

            Console.WriteLine("Add InvoicesFooters...");
            invoicesfooters invoicesfooters01 = new invoicesfooters()
            {
                invoicesfooters_name = "Footer 01",
                invoicesfooters_doctext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
            };
            _dentnedModel.InvoicesFooters.Add(invoicesfooters01);

            Console.WriteLine("Add EstimatesFooters...");
            estimatesfooters estimatesfooters01 = new estimatesfooters()
            {
                estimatesfooters_name = "Footer 01",
                estimatesfooters_doctext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
            };
            _dentnedModel.EstimatesFooters.Add(estimatesfooters01);

            Console.WriteLine("Add PaymentsTypes...");
            paymentstypes paymentstypesCash = new paymentstypes()
            {
                paymentstypes_name = "Cash",
                paymentstypes_doctext = "Pay by cash"
            };
            _dentnedModel.PaymentsTypes.Add(paymentstypesCash);

            Console.WriteLine("Add PatientsAttachmentsTypes...");
            patientsattachmentstypes[] patientsattachmentstypes = new patientsattachmentstypes[] { };
            for (int i = 0; i < patientsattachmentstypesNum; i++)
            {
                patientsattachmentstypes patientsattachmentstypestmp = new patientsattachmentstypes()
                {
                    patientsattachmentstypes_name = "AttachmentsT " + (i + 1),
                    patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
                };
                _dentnedModel.PatientsAttachmentsTypes.Add(patientsattachmentstypestmp);
                patientsattachmentstypes = patientsattachmentstypes.Concat(new patientsattachmentstypes[] { patientsattachmentstypestmp }).ToArray();
            }

            Console.WriteLine("Add PatientsAttributesTypes...");
            patientsattributestypes patientsattributestypesSendAppointmentsReminder = new patientsattributestypes()
            {
                patientsattributestypes_name = PatientsAttributesTypesRepository.SystemAttributes.SendAppointmentsReminder.ToString(),
            };
            _dentnedModel.PatientsAttributesTypes.Add(patientsattributestypesSendAppointmentsReminder);
            patientsattributestypes patientsattributestypesAge = new patientsattributestypes()
            {
                patientsattributestypes_name = "Age",
            };
            _dentnedModel.PatientsAttributesTypes.Add(patientsattributestypesAge);

            Console.WriteLine("Add TreatmentsTypes...");
            treatmentstypes[] treatmentstypes = new treatmentstypes[] { };
            for (int i = 0; i < treatmentstypesNum; i++)
            {
                treatmentstypes treatmentstypestmp = new treatmentstypes()
                {
                    treatmentstypes_name = "TreatmentsT " + (i + 1),
                };
                _dentnedModel.TreatmentsTypes.Add(treatmentstypestmp);
                treatmentstypes = treatmentstypes.Concat(new treatmentstypes[] { treatmentstypestmp }).ToArray();
            }

            Console.WriteLine("Add TreatmentsPricesLists...");
            treatmentspriceslists[] treatmentspriceslists = new treatmentspriceslists[] { };
            for (int i = 0; i < treatmentspriceslistsNum; i++)
            {
                treatmentspriceslists treatmentspricesliststmp = new treatmentspriceslists()
                {
                    treatmentspriceslists_name = "TreatmentsT " + (i + 1),
                    treatmentspriceslists_multiplier = (decimal)(_r.NextDouble() * (2 - 1) + 1)
                };
                _dentnedModel.TreatmentsPricesLists.Add(treatmentspricesliststmp);
                treatmentspriceslists = treatmentspriceslists.Concat(new treatmentspriceslists[] { treatmentspricesliststmp }).ToArray();
            }

            Console.WriteLine("Add Treatments...");
            treatments[] treatments = new treatments[] { };
            for (int i = 0; i < treatmentsNum; i++)
            {
                treatments treatmentstmp = new treatments()
                {
                    treatmentstypes_id = treatmentstypes[_r.Next(treatmentstypes.Count())].treatmentstypes_id,
                    treatments_code = (i + 1).ToString().PadLeft(3, '0'),
                    treatments_name = "Treatments " + (i + 1).ToString().PadLeft(3, '0'),
                    treatments_mexpiration = (_r.Next(0, 100) >= 80 ? (Nullable<byte>)_r.Next(1, 12) : null),
                    treatments_price = (decimal)(_r.NextDouble() * (300 - 1) + 300),
                    taxes_id = taxesT22.taxes_id,
                    treatments_isunitprice = (_r.Next(0, 100) >= 50 ? true : false)
                };
                _dentnedModel.Treatments.Add(treatmentstmp);
                treatments = treatments.Concat(new treatments[] { treatmentstmp }).ToArray();
            }

            Console.WriteLine("Add TreatmentsPrices...");
            treatmentsprices[] treatmentsprices = new treatmentsprices[] { };
            foreach (treatments treatment in treatments)
            {
                if (_r.Next(0, 100) >= 30)
                {
                    treatmentspriceslists treatmentspriceslist = treatmentspriceslists[_r.Next(treatmentspriceslists.Count())];
                    treatmentsprices treatmentspricestmp = new treatmentsprices()
                    {
                        treatments_id = treatment.treatments_id,
                        treatmentspriceslists_id = treatmentspriceslist.treatmentspriceslists_id,
                        treatmentsprices_price = treatment.treatments_price + treatment.treatments_price * treatmentspriceslist.treatmentspriceslists_multiplier
                    };
                    _dentnedModel.TreatmentsPrices.Add(treatmentspricestmp);
                    treatmentsprices = treatmentsprices.Concat(new treatmentsprices[] { treatmentspricestmp }).ToArray();
                }
            }

            Console.WriteLine("Add Patients...");
            patients[] patients = new patients[] { };
            for (int i = 0; i < _patientsNum; i++)
            {
                patients patientstmp = new patients()
                {
                    patients_name = "Name " + (i + 1).ToString(),
                    patients_surname = "Surname " + (i + 1).ToString(),
                    patients_birthdate = GetRandomDate(new DateTime(1950, 1, 1), new DateTime(2010, 12, 31)),
                    patients_birthcity = BuildRandomString(_r.Next(5, 20)),
                    patients_doctext = "Name " + (i + 1).ToString() + " " + "Surname " + (i + 1).ToString() + "\r\n" + "Street " + BuildRandomString(_r.Next(5, 30)) + ", " + _r.Next(1, 100) + "\r\n" + BuildRandomString(_r.Next(5, 20)) + (_r.Next(0, 100) > 50 ? "\r\n" + "VAT " + BuildRandomString(10) : ""),
                    patients_sex = (_r.Next(0, 100) > 50 ? "M" : "F"),
                    patients_username = (i + 1).ToString().PadLeft(8, '0'),
                    patients_password = (i + 1).ToString().PadLeft(6, '0'),
                    patients_isarchived = (_r.Next(0, 100) > 5 ? false : true),
                    treatmentspriceslists_id = (_r.Next(0, 100) > 20 ? (Nullable<int>)treatmentspriceslists[_r.Next(treatmentspriceslists.Count())].treatmentspriceslists_id : null)
                };
                _dentnedModel.Patients.Add(patientstmp);
                patients = patients.Concat(new patients[] { patientstmp }).ToArray();

                if (generatedatafiles)
                {
                    if (_r.Next(0, 100) > 50)
                    {
                        if (!Directory.Exists(_patientsDatadir + "\\" + patientstmp.patients_id))
                            Directory.CreateDirectory(_patientsDatadir + "\\" + patientstmp.patients_id);
                        GenerateImage(_patientsDatadir + "\\" + patientstmp.patients_id + "\\" + BuildRandomString(12) + ".png");
                    }
                }
            }

            Console.WriteLine("Add PatientsAddresses...");
            foreach (patients patient in patients)
            {
                do
                {
                    _dentnedModel.PatientsAddresses.Add(new patientsaddresses()
                    {
                        patients_id = patient.patients_id,
                        addressestypes_id = addressestypesHome.addressestypes_id,
                        patientsaddresses_state = BuildRandomString(2),
                        patientsaddresses_city = BuildRandomString(_r.Next(5, 10)),
                        patientsaddresses_street = BuildRandomString(_r.Next(5, 30)),
                        patientsaddresses_zipcode = _r.Next(1, 99999).ToString().PadLeft(5, '0')
                    });
                } while (_r.Next(0, 100) > 80);
            }

            Console.WriteLine("Add PatientsAttributes...");
            foreach (patients patient in patients)
            {
                do
                {
                    _dentnedModel.PatientsAttributes.Add(new patientsattributes()
                    {
                        patients_id = patient.patients_id,
                        patientsattributestypes_id = patientsattributestypesAge.patientsattributestypes_id,
                        patientsattributes_value = _r.Next(10, 100).ToString()
                    });
                } while (_r.Next(0, 100) > 80);
            }

            Console.WriteLine("Add PatientsContacts...");
            foreach (patients patient in patients)
            {
                do
                {
                    _dentnedModel.PatientsContacts.Add(new patientscontacts()
                    {
                        patients_id = patient.patients_id,
                        contactstypes_id = contactstypesMobile.contactstypes_id,
                        patientscontacts_value = _r.Next(1, 999).ToString().PadLeft(3, '0') + "/" + _r.Next(1, 999).ToString().PadLeft(3, '0') + _r.Next(1, 999).ToString().PadLeft(3, '0')
                    });
                } while (_r.Next(0, 100) > 80);
            }

            Console.WriteLine("Add PatientsMedicalrecords...");
            foreach (patients patient in patients)
            {
                do
                {
                    _dentnedModel.PatientsMedicalrecords.Add(new patientsmedicalrecords()
                    {
                        patients_id = patient.patients_id,
                        medicalrecordstypes_id = medicalrecordstypes[_r.Next(medicalrecordstypes.Count())].medicalrecordstypes_id,
                        patientsmedicalrecords_value = BuildRandomString(_r.Next(10, 50))
                    });
                } while (_r.Next(0, 100) > 50);
            }

            Console.WriteLine("Add PatientsNotes...");
            foreach (patients patient in patients)
            {
                if (_r.Next(0, 100) > 50)
                {
                    do
                    {
                        _dentnedModel.PatientsNotes.Add(new patientsnotes()
                        {
                            patients_id = patient.patients_id,
                            patientsnotes_date = GetRandomDate(new DateTime(2013, 1, 1), new DateTime(2015, 12, 31)),
                            patientsnotes_text = BuildRandomString(_r.Next(10, 200))
                        });
                    } while (_r.Next(0, 100) > 50);
                }
            }

            Console.WriteLine("Add PatientsAttachments...");
            foreach (patients patient in patients)
            {
                if (_r.Next(0, 100) > 50)
                {
                    do
                    {
                        string filename = null;

                        if (generatedatafiles)
                        {
                            if (_r.Next(0, 100) > 50)
                            {
                                filename = BuildRandomString(12) + ".png";
                                if (!Directory.Exists(_patientsAttachmentsdir + "\\" + patient.patients_id))
                                    Directory.CreateDirectory(_patientsAttachmentsdir + "\\" + patient.patients_id);
                                GenerateImage(_patientsAttachmentsdir + "\\" + patient.patients_id + "\\" + filename);
                            }
                        }

                        _dentnedModel.PatientsAttachments.Add(new patientsattachments()
                        {
                            patients_id = patient.patients_id,
                            patientsattachmentstypes_id = patientsattachmentstypes[_r.Next(patientsattachmentstypes.Count())].patientsattachmentstypes_id,
                            patientsattachments_value = BuildRandomString(_r.Next(10, 50)),
                            patientsattachments_date = GetRandomDate(new DateTime(2013, 1, 1), new DateTime(2015, 12, 31)),
                            patientsattachments_filename = filename
                        });



                    } while (_r.Next(0, 100) > 50);
                }
            }

            Console.WriteLine("Add Appointments...");
            foreach (patients patient in patients)
            {
                do
                {
                    DateTime from = GetRandomDate(new DateTime(2013, 1, 1), new DateTime(2015, 12, 31));
                    from = new DateTime(from.Year, from.Month, from.Day, _r.Next(8, 19), (_r.Next(0, 100) > 50 ? 0 : 30), 0);
                    DateTime to = (_r.Next(0, 100) > 50 ? from.AddMinutes(30) : from.AddHours(_r.Next(1, 2)));
                    _dentnedModel.Appointments.Add(new appointments()
                    {
                        patients_id = patient.patients_id,
                        doctors_id = doctorsTest.doctors_id,
                        rooms_id = rooms[_r.Next(rooms.Count())].rooms_id,
                        appointments_title = BuildRandomString(_r.Next(5, 25)),
                        appointments_from = from,
                        appointments_to = to
                    });
                } while (_r.Next(0, 100) > 3);
            }

            Console.WriteLine("Add PatientsTreatments...");
            foreach (patients patient in patients)
            {
                do
                {
                    treatments treatment = treatments[_r.Next(treatments.Count())];
                    DateTime creationdate = GetRandomDate(new DateTime(2013, 1, 1), new DateTime(2015, 12, 31));
                    _dentnedModel.PatientsTreatments.Add(new patientstreatments()
                    {
                        doctors_id = doctorsTest.doctors_id,
                        patients_id = patient.patients_id,
                        treatments_id = treatment.treatments_id,
                        patientstreatments_id = treatment.treatments_id,
                        patientstreatments_creationdate = creationdate,
                        patientstreatments_price = treatment.treatments_price,
                        patientstreatments_taxrate = taxesT22.taxes_rate,
                        patientstreatments_description = treatment.treatments_code + " " + treatment.treatments_name,
                        patientstreatments_notes = (_r.Next(0, 100) > 50 ? BuildRandomString(50) : null),
                        patientstreatments_fulfilldate = (_r.Next(0, 100) > 50 ? (Nullable<DateTime>)creationdate.AddDays(_r.Next(0, 10)) : null),
                        patientstreatments_expirationdate = (treatment.treatments_mexpiration != null ? (Nullable<DateTime>)creationdate.AddMonths((byte)treatment.treatments_mexpiration) : null),
                        patientstreatments_ispaid = (_r.Next(0, 100) > 20 ? true : false),
                        patientstreatments_isunitprice = treatment.treatments_isunitprice,
                        patientstreatments_t11 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t12 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t13 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t14 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t15 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t16 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t17 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t18 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t21 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t22 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t23 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t24 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t25 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t26 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t27 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t28 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t31 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t32 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t33 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t34 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t35 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t36 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t37 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t38 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t41 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t42 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t43 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t44 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t45 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t46 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t47 = (_r.Next(0, 100) > 90 ? true : false),
                        patientstreatments_t48 = (_r.Next(0, 100) > 90 ? true : false)
                    });
                } while (_r.Next(0, 100) > 30);
            }

            Console.WriteLine("Add Payments...");
            foreach (patientstreatments patientstreatment in _dentnedModel.PatientsTreatments.List())
            {
                if (patientstreatment.patientstreatments_fulfilldate != null)
                {
                    if (_r.Next(0, 100) > 20)
                    {
                        int quantity = 1;
                        if (patientstreatment.patientstreatments_isunitprice)
                        {
                            quantity = _dentnedModel.PatientsTreatments.GetNumberOfTooths(patientstreatment);
                            if (quantity == 0)
                                quantity = 1;
                        }

                        _dentnedModel.Payments.Add(new payments()
                        {
                            payments_amount = quantity * (patientstreatment.patientstreatments_price + (patientstreatment.patientstreatments_price * patientstreatment.patientstreatments_taxrate / 100)) + (_r.Next(0, 100) > 50 ? (decimal)(_r.NextDouble() * 2) : 0),
                            payments_date = ((DateTime)patientstreatment.patientstreatments_fulfilldate).AddDays(_r.Next(1, 30)),
                            patients_id = patientstreatment.patients_id
                        });
                    }
                }
            }

            Console.WriteLine("Add Estimates and EstimatesLines...");
            foreach (patients patient in patients)
            {
                do
                {
                    DateTime date = GetRandomDate(new DateTime(2013, 1, 1), new DateTime(2015, 12, 31));
                    estimates estimate = new estimates()
                    {
                        estimates_date = date,
                        estimates_number = (_dentnedModel.Estimates.List(r => r.estimates_date.Year == date.Year).Count + 1).ToString(),
                        doctors_id = doctorsTest.doctors_id,
                        patients_id = patient.patients_id,
                        estimates_doctor = doctorsTest.doctors_doctext,
                        estimates_patient = patient.patients_doctext,
                        estimates_footer = estimatesfooters01.estimatesfooters_doctext,
                        estimates_payment = paymentstypesCash.paymentstypes_doctext,
                        estimates_totalnet = 0,
                        estimates_totalgross = 0,
                        estimates_totaldue = 0,
                        estimates_deductiontaxrate = ((_r.Next(0, 100) > 50) ? taxesdeductionsTD1.taxesdeductions_rate : 0)
                    };
                    _dentnedModel.Estimates.Add(estimate);

                    do
                    {
                        treatments treatment = null;
                        patientstreatments patientstreatment = null;
                        int quantity = _r.Next(1, 3);
                        if (_r.Next(0, 100) > 80)
                        {
                            patientstreatment = _dentnedModel.PatientsTreatments.FirstOrDefault(r => r.patients_id == patient.patients_id);
                            if (patientstreatment != null)
                            {
                                treatment = _dentnedModel.Treatments.Find(patientstreatment.treatments_id);
                                if (patientstreatment.patientstreatments_isunitprice)
                                {
                                    quantity = _dentnedModel.PatientsTreatments.GetNumberOfTooths(patientstreatment);
                                    if (quantity == 0)
                                        quantity = 1;
                                }
                            }
                        }
                        if (treatment == null)
                            treatment = treatments[_r.Next(treatments.Count())];

                        _dentnedModel.EstimatesLines.Add(new estimateslines()
                        {
                            estimates_id = estimate.estimates_id,
                            estimateslines_code = treatment.treatments_code,
                            estimateslines_description = treatment.treatments_code + " " + treatment.treatments_name,
                            estimateslines_quantity = quantity,
                            estimateslines_unitprice = treatment.treatments_price,
                            estimateslines_taxrate = (_r.Next(0, 100) > 50 ? 0 : (_r.Next(0, 100) > 50 ? taxesT22.taxes_rate : taxesT04.taxes_rate)),
                            estimateslines_istaxesdeductionsable = true,
                            patientstreatments_id = (patientstreatment != null ? (Nullable<int>)patientstreatment.patientstreatments_id : null),
                        });
                    } while (_r.Next(0, 100) > 30);


                } while (_r.Next(0, 100) > 30);
            }

            Console.WriteLine("Add Invoices and InvoicesLines...");
            foreach (patients patient in patients)
            {
                do
                {
                    DateTime date = GetRandomDate(new DateTime(2013, 1, 1), new DateTime(2015, 12, 31));
                    invoices invoice = new invoices()
                    {
                        invoices_date = date,
                        invoices_number = (_dentnedModel.Invoices.List(r => r.invoices_date.Year == date.Year).Count + 1).ToString(),
                        doctors_id = doctorsTest.doctors_id,
                        patients_id = patient.patients_id,
                        invoices_doctor = doctorsTest.doctors_doctext,
                        invoices_patient = patient.patients_doctext,
                        invoices_footer = invoicesfooters01.invoicesfooters_doctext,
                        invoices_payment = paymentstypesCash.paymentstypes_doctext,
                        invoices_totalnet = 0,
                        invoices_totalgross = 0,
                        invoices_totaldue = 0,
                        invoices_deductiontaxrate = ((_r.Next(0, 100) > 50) ? taxesdeductionsTD1.taxesdeductions_rate : 0),
                        invoices_ispaid = ((_r.Next(0, 100) > 20) ? false : true)
                    };
                    _dentnedModel.Invoices.Add(invoice);

                    do
                    {
                        treatments treatment = null;
                        patientstreatments patientstreatment = null;
                        int quantity = _r.Next(1, 3);
                        if (_r.Next(0, 100) > 80)
                        {
                            patientstreatment = _dentnedModel.PatientsTreatments.FirstOrDefault(r => r.patients_id == patient.patients_id);
                            if (patientstreatment != null)
                            {
                                if (patientstreatment.patientstreatments_isunitprice)
                                {
                                    quantity = _dentnedModel.PatientsTreatments.GetNumberOfTooths(patientstreatment);
                                    if (quantity == 0)
                                        quantity = 1;
                                }
                                treatment = _dentnedModel.Treatments.Find(patientstreatment.treatments_id);
                            }
                        }
                        if (treatment == null)
                            treatment = treatments[_r.Next(treatments.Count())];

                        _dentnedModel.InvoicesLines.Add(new invoiceslines()
                        {
                            invoices_id = invoice.invoices_id,
                            invoiceslines_code = treatment.treatments_code,
                            invoiceslines_description = treatment.treatments_code + " " + treatment.treatments_name,
                            invoiceslines_quantity = quantity,
                            invoiceslines_unitprice = treatment.treatments_price,
                            invoiceslines_taxrate = (_r.Next(0, 100) > 50 ? 0 : (_r.Next(0, 100) > 50 ? taxesT22.taxes_rate : taxesT04.taxes_rate)),
                            invoiceslines_istaxesdeductionsable = true,
                            patientstreatments_id = (patientstreatment != null ? (Nullable<int>)patientstreatment.patientstreatments_id : null),
                        });
                    } while (_r.Next(0, 100) > 30);


                } while (_r.Next(0, 100) > 30);
            }

        }

        private DateTime GetRandomDate(DateTime from, DateTime to)
        {
            TimeSpan range = to - from;
            TimeSpan randTimeSpan = new TimeSpan((long)(_r.NextDouble() * range.Ticks));
            return from + randTimeSpan;
        }

        public string BuildRandomString(int size)
        {
            string input = "abcdefghijklmnopqrstuvwxyz0123456789 ";
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = input[r.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public static void GenerateImage(string filename)
        {
            using (Bitmap b = new Bitmap(50, 50))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.Clear(Color.Green);
                }
                b.Save(filename, ImageFormat.Png);
            }
        }
    }
}
