﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace seozillabackend.Extensions
{
    public class listof
    {
        public static List<SelectListItem> countries = new List<SelectListItem>() { 
                new SelectListItem(){ Text="Afghanistan", Value="Afghanistan"},
                 new SelectListItem(){ Text="Albania", Value="Albania"},
                   new SelectListItem(){ Text="Algeria", Value="Algeria"},
                   new SelectListItem(){ Text="American Samoa", Value="American Samoa"},
                    new SelectListItem(){ Text="Andorra", Value="Andorra"},
               new SelectListItem(){ Text="Angola", Value="Angola"},
                  new SelectListItem(){ Text="Anguilla", Value="Anguilla"},
                     new SelectListItem(){ Text="Antarctica", Value="Antarctica"},
                      new SelectListItem(){ Text="Antigua and Barbuda", Value="Antigua and Barbuda"},
                    new SelectListItem(){ Text="Argentina", Value="Argentina"},
                    new SelectListItem(){ Text="Armenia", Value="Armenia"},
                      new SelectListItem(){ Text="Aruba", Value="Aruba"},
                      new SelectListItem(){ Text="Australia", Value="Australia"},
                      new SelectListItem(){ Text="Austria", Value="Austria"},
                      new SelectListItem(){ Text="Azerbaijan", Value="Azerbaijan"},
                      new SelectListItem(){ Text="Bahamas", Value="Bahamas"},
                      new SelectListItem(){ Text="Bahrain", Value="Bahrain"},
                       new SelectListItem(){ Text="Bangladesh", Value="Bangladesh"},
                        new SelectListItem(){ Text="Barbados", Value="Barbados"},
                        new SelectListItem(){ Text="Belarus", Value="Belarus"},
                        new SelectListItem(){ Text="Belgium", Value="Belgium"},
                        new SelectListItem(){ Text="Belize", Value="Belize"},
                        new SelectListItem(){ Text="Benin", Value="Benin"},
                        new SelectListItem(){ Text="Bermuda", Value="Bermuda"},
                        new SelectListItem(){ Text="Bhutan", Value="Bhutan"},
                        new SelectListItem(){ Text="Bolivia", Value="Bolivia"},
                        new SelectListItem(){ Text="Bosnia and Herzegovina", Value="Bosnia and Herzegovina"},
                        new SelectListItem(){ Text="Botswana", Value="Botswana"},
                        new SelectListItem(){ Text="Bouvet Island", Value="Bouvet Island"},
                        new SelectListItem(){ Text="Brazil", Value="Brazil"},
                         new SelectListItem(){ Text="British Indian Ocean Territory", Value="British Indian Ocean Territory"},
                         new SelectListItem(){ Text="Brunei Darussalam", Value="Brunei Darussalam"},
                         new SelectListItem(){ Text="Bulgaria", Value="Bulgaria"},
                         new SelectListItem(){ Text="Burkina Faso", Value="Burkina Faso"},
                          new SelectListItem(){ Text="Burundi", Value="Burundi"},
                           new SelectListItem(){ Text="Cambodia", Value="Cambodia"},
                           new SelectListItem(){ Text="Cameroon", Value="Cameroon"},
                            new SelectListItem(){ Text="Canada", Value="Canada"},
                            new SelectListItem(){ Text="Cape Verde", Value="Cape Verde"},
                             new SelectListItem(){ Text="Cayman Islands", Value="Cayman Islands"},
                              new SelectListItem(){ Text="Central African Republic", Value="Central African Republic"},
                              new SelectListItem(){ Text="Chad", Value="Chad"},
                               new SelectListItem(){ Text="Chile", Value="Chile"},
                               new SelectListItem(){ Text="China", Value="China"},
                               new SelectListItem(){ Text="Christmas Island", Value="Christmas Island"},
                               new SelectListItem(){ Text="Cocos (Keeling) Islands", Value="Cocos (Keeling) Islands"},
                               new SelectListItem(){ Text="Colombia", Value="Colombia"},
                         new SelectListItem(){ Text="Comoros", Value="Comoros"},
                         new SelectListItem(){ Text="Congo", Value="Congo"},
                         new SelectListItem(){ Text="Congo, the Democratic Republic of the", Value="Congo, the Democratic Republic of the"},
                         new SelectListItem(){ Text="Cook Islands", Value="Cook Islands"},
                         new SelectListItem(){ Text="Costa Rica", Value="Costa Rica"},
                         new SelectListItem(){ Text="Cote D'Ivoire", Value="Cote D'Ivoire"},
                          new SelectListItem(){ Text="Croatia", Value="Croatia"},
                          new SelectListItem(){ Text="Cuba", Value="Cuba"},
                          new SelectListItem(){ Text="Cyprus", Value="Cyprus"},
                          new SelectListItem(){ Text="Czech Republic", Value="Czech Republic"},
                          new SelectListItem(){ Text="Denmark", Value="Denmark"},
                          new SelectListItem(){ Text="Djibouti", Value="Djibouti"},
                          new SelectListItem(){ Text="Dominica", Value="Dominica"},
                         
                          new SelectListItem(){ Text="Dominican Republic", Value="Dominican Republic"},
                           new SelectListItem(){ Text="Ecuador", Value="Ecuador"},
                          new SelectListItem(){ Text="Egypt", Value="Egypt"},
                          new SelectListItem(){ Text="El Salvador", Value="El Salvador"},
                          new SelectListItem(){ Text="Equatorial Guinea", Value="Equatorial Guinea"},
                          new SelectListItem(){ Text="Eritrea", Value="Eritrea"},
                          new SelectListItem(){ Text="Estonia", Value="Estonia"},
                          new SelectListItem(){ Text="Ethiopia", Value="Ethiopia"},
                          new SelectListItem(){ Text="Falkland Islands (Malvinas)", Value="Falkland Islands (Malvinas)"},
                          new SelectListItem(){ Text="Faroe Islands", Value="Faroe Islands"},
                          new SelectListItem(){ Text="Fiji", Value="Fiji"},
                          new SelectListItem(){ Text="Finland", Value="Finland"},
                          new SelectListItem(){ Text="France", Value="France"},
                          new SelectListItem(){ Text="French Guiana", Value="French Guiana"},
                          new SelectListItem(){ Text="French Polynesia", Value="French Polynesia"},
                          new SelectListItem(){ Text="French Southern Territories", Value="French Southern Territories"},
                          new SelectListItem(){ Text="Gabon", Value="Gabon"},

                          new SelectListItem(){ Text="Gambia", Value="Gambia"},
                          new SelectListItem(){ Text="Georgia", Value="Georgia"},
                          new SelectListItem(){ Text="Germany", Value="Germany"},
                          new SelectListItem(){ Text="Ghana", Value="Ghana"},
                          new SelectListItem(){ Text="Gibraltar", Value="Gibraltar"},
                          new SelectListItem(){ Text="Greece", Value="Greece"},

                          new SelectListItem(){ Text="Greenland", Value="Greenland"},
                          new SelectListItem(){ Text="Grenada", Value="Grenada"},
                          new SelectListItem(){ Text="Guadeloupe", Value="Guadeloupe"},
                          new SelectListItem(){ Text="Guam", Value="Guam"},
                          new SelectListItem(){ Text="Guatemala", Value="Guatemala"},
                          new SelectListItem(){ Text="Guinea", Value="Guinea"},


                           new SelectListItem(){ Text="Guinea-Bissau", Value="Guinea-Bissau"},
                          new SelectListItem(){ Text="Guyana", Value="Guyana"},
                          new SelectListItem(){ Text="Haiti", Value="Haiti"},
                          new SelectListItem(){ Text="Heard Island and Mcdonald Islands", Value="Heard Island and Mcdonald Islands"},
                          new SelectListItem(){ Text="Holy See (Vatican City State)", Value="Holy See (Vatican City State)"},
                          new SelectListItem(){ Text="Honduras", Value="Honduras"},


                          new SelectListItem(){ Text="Hong Kong", Value="Hong Kong"},
                          new SelectListItem(){ Text="Hungary", Value="Hungary"},
                          new SelectListItem(){ Text="Iceland", Value="Iceland"},
                          new SelectListItem(){ Text="India", Value="India"},
                          new SelectListItem(){ Text="Indonesia", Value="Indonesia"},
                          new SelectListItem(){ Text="Iran, Islamic Republic of", Value="Iran, Islamic Republic of"},
                          new SelectListItem(){ Text="Iraq", Value="Iraq"},

                           new SelectListItem(){ Text="Ireland", Value="Ireland"},
                          new SelectListItem(){ Text="Israel", Value="Israel"},
                          new SelectListItem(){ Text="Italy", Value="Italy"},
                          new SelectListItem(){ Text="Jamaica", Value="Jamaica"},
                          new SelectListItem(){ Text="Japan", Value="Japan"},
                          new SelectListItem(){ Text="Jordan", Value="Jordan"},

                           new SelectListItem(){ Text="Kazakhstan", Value="Kazakhstan"},
                          new SelectListItem(){ Text="Kenya", Value="Kenya"},
                          new SelectListItem(){ Text="Kiribati", Value="Kiribati"},
                          new SelectListItem(){ Text="Korea, Democratic People's Republic of", Value="Korea, Democratic People's Republic of"},
                          new SelectListItem(){ Text="Korea, Republic of", Value="Korea, Republic of"},
                          new SelectListItem(){ Text="Kuwait", Value="Kuwait"},
                          new SelectListItem(){ Text="Kyrgyzstan", Value="Kyrgyzstan"},
                      
                           new SelectListItem(){ Text="Lao People's Democratic Republic", Value="Lao People's Democratic Republic"},
                          new SelectListItem(){ Text="Latvia", Value="Latvia"},
                          new SelectListItem(){ Text="Lebanon", Value="Lebanon"},
                          new SelectListItem(){ Text="Lesotho", Value="Lesotho"},
                          new SelectListItem(){ Text="Liberia", Value="Liberia"},
                          new SelectListItem(){ Text="Libyan Arab Jamahiriya", Value="Libyan Arab Jamahiriya"},

                          new SelectListItem(){ Text="Liechtenstein", Value="Liechtenstein"},
                          new SelectListItem(){ Text="Lithuania", Value="Lithuania"},
                          new SelectListItem(){ Text="Luxembourg", Value="Luxembourg"},
                          new SelectListItem(){ Text="Macao", Value="Macao"},
                          new SelectListItem(){ Text="Macedonia, the Former Yugoslav Republic of", Value="Macedonia, the Former Yugoslav Republic of"},
                          new SelectListItem(){ Text="Madagascar", Value="Madagascar"},

                           new SelectListItem(){ Text="Malawi", Value="Malawi"},
                          new SelectListItem(){ Text="Malaysia", Value="Malaysia"},
                          new SelectListItem(){ Text="Maldives", Value="Maldives"},
                          new SelectListItem(){ Text="Mali", Value="Mali"},
                          new SelectListItem(){ Text="Malta", Value="Malta"},
                          new SelectListItem(){ Text="Marshall Islands", Value="Marshall Islands"},


                          new SelectListItem(){ Text="Martinique", Value="Martinique"},
                          new SelectListItem(){ Text="Mauritania", Value="Mauritania"},
                          new SelectListItem(){ Text="Mauritius", Value="Mauritius"},
                          new SelectListItem(){ Text="Mayotte", Value="Mayotte"},
                          new SelectListItem(){ Text="Mexico", Value="Mexico"},
                          new SelectListItem(){ Text="Micronesia, Federated States of", Value="Micronesia, Federated States of"},

                          new SelectListItem(){ Text="Moldova, Republic of", Value="Moldova, Republic of"},
                          new SelectListItem(){ Text="Monaco", Value="Monaco"},
                          new SelectListItem(){ Text="Mongolia", Value="Mongolia"},
                          new SelectListItem(){ Text="Montserrat", Value="Montserrat"},
                          new SelectListItem(){ Text="Morocco", Value="Morocco"},
                          new SelectListItem(){ Text="Mozambique", Value="Mozambique"},


                           new SelectListItem(){ Text="Myanmar", Value="Myanmar"},
                          new SelectListItem(){ Text="Namibia", Value="Namibia"},
                          new SelectListItem(){ Text="Nauru", Value="Nauru"},
                          new SelectListItem(){ Text="Nepal", Value="Nepal"},
                          new SelectListItem(){ Text="Netherlands", Value="Netherlands"},
                          new SelectListItem(){ Text="Netherlands Antilles", Value="Netherlands Antilles"},
                          new SelectListItem(){ Text="New Caledonia", Value="New Caledonia"},

                           new SelectListItem(){ Text="New Zealand", Value="New Zealand"},
                          new SelectListItem(){ Text="Nicaragua", Value="Nicaragua"},
                          new SelectListItem(){ Text="Niger", Value="Niger"},
                          new SelectListItem(){ Text="Nigeria", Value="Nigeria"},
                          new SelectListItem(){ Text="Niue", Value="Niue"},
                          new SelectListItem(){ Text="Norfolk Island", Value="Norfolk Island"},


 
                          new SelectListItem(){ Text="Northern Mariana Islands", Value="Northern Mariana Islands"},
                          new SelectListItem(){ Text="Norway", Value="Norway"},
                          new SelectListItem(){ Text="Oman", Value="Oman"},
                          new SelectListItem(){ Text="Pakistan", Value="Pakistan"},
                          new SelectListItem(){ Text="Palau", Value="Palau"},
                          new SelectListItem(){ Text="Palestinian Territory, Occupied", Value="Palestinian Territory, Occupied"},

 
                          new SelectListItem(){ Text="Panama", Value="Panama"},
                          new SelectListItem(){ Text="Papua New Guinea", Value="Papua New Guinea"},
                          new SelectListItem(){ Text="Paraguay", Value="Paraguay"},
                          new SelectListItem(){ Text="Peru", Value="Peru"},
                          new SelectListItem(){ Text="Philippines", Value="Philippines"},
                          new SelectListItem(){ Text="Pitcairn", Value="Pitcairn"},
                          new SelectListItem(){ Text="Poland", Value="Poland"},
                          new SelectListItem(){ Text="Portugal", Value="Portugal"},
                          new SelectListItem(){ Text="Puerto Rico", Value="Puerto Rico"},
                           new SelectListItem(){ Text="Qatar", Value="Qatar"},

                            new SelectListItem(){ Text="Reunion", Value="Reunion"},
                          new SelectListItem(){ Text="Romania", Value="Romania"},
                          new SelectListItem(){ Text="Russian Federation", Value="Russian Federation"},
                           new SelectListItem(){ Text="Rwanda", Value="Rwanda"},


                           new SelectListItem(){ Text="Saint Helena", Value="Saint Helena"},
                          new SelectListItem(){ Text="Saint Kitts and Nevis", Value="Saint Kitts and Nevis"},
                          new SelectListItem(){ Text="Saint Lucia", Value="Saint Lucia"},
                           new SelectListItem(){ Text="Saint Pierre and Miquelon", Value="Saint Pierre and Miquelon"},

 
                           new SelectListItem(){ Text="Saint Vincent and the Grenadines", Value="Saint Vincent and the Grenadines"},
                          new SelectListItem(){ Text="Samoa", Value="Samoa"},
                          new SelectListItem(){ Text="San Marino", Value="San Marino"},
                          new SelectListItem(){ Text="Sao Tome and Principe", Value="Sao Tome and Principe"},
                          new SelectListItem(){ Text="Saudi Arabia", Value="Saudi Arabia"},
                          new SelectListItem(){ Text="Senegal", Value="Senegal"},

                          new SelectListItem(){ Text="Serbia and Montenegro", Value="Serbia and Montenegro"},
                          new SelectListItem(){ Text="Seychelles", Value="Seychelles"},
                          new SelectListItem(){ Text="Sierra Leone", Value="Sierra Leone"},
                          new SelectListItem(){ Text="Singapore", Value="Singapore"},
                          new SelectListItem(){ Text="Slovakia", Value="Slovakia"},


  
                          new SelectListItem(){ Text="Solomon Islands", Value="Solomon Islands"},
                          new SelectListItem(){ Text="Somalia", Value="Somalia"},
                          new SelectListItem(){ Text="South Africa", Value="South Africa"},
                          new SelectListItem(){ Text="South Georgia and the South Sandwich Islands", Value="South Georgia and the South Sandwich Islands"},
                          new SelectListItem(){ Text="Spain", Value="Spain"},
                          new SelectListItem(){ Text="Sri Lanka", Value="Sri Lanka"},
                           
                          new SelectListItem(){ Text="Sudan", Value="Sudan"},
                          new SelectListItem(){ Text="Suriname", Value="Suriname"},
                          new SelectListItem(){ Text="Svalbard and Jan Mayen", Value="Svalbard and Jan Mayen"},
                          new SelectListItem(){ Text="Swaziland", Value="Swaziland"},
                          new SelectListItem(){ Text="Sweden", Value="Sweden"},
                          new SelectListItem(){ Text="Switzerland", Value="Switzerland"},

                          new SelectListItem(){ Text="Syrian Arab Republic", Value="Syrian Arab Republic"},
                          new SelectListItem(){ Text="Taiwan, Province of China", Value="Taiwan, Province of China"},
                          new SelectListItem(){ Text="Tajikistan", Value="Tajikistan"},
                          new SelectListItem(){ Text="Tanzania, United Republic of", Value="Tanzania, United Republic of"},
                          new SelectListItem(){ Text="Thailand", Value="Thailand"},
                          new SelectListItem(){ Text="Timor-Leste", Value="Timor-Leste"},

                          new SelectListItem(){ Text="Togo", Value="Togo"},
                          new SelectListItem(){ Text="Tokelau", Value="Tokelau"},
                          new SelectListItem(){ Text="Tonga", Value="Tonga"},
                          new SelectListItem(){ Text="Trinidad and Tobago", Value="Trinidad and Tobago"},
                          new SelectListItem(){ Text="Tunisia", Value="Tunisia"},
                          new SelectListItem(){ Text="Turkey", Value="Turkey"},

                          new SelectListItem(){ Text="Turkmenistan", Value="Turkmenistan"},
                          new SelectListItem(){ Text="Turks and Caicos Islands", Value="Turks and Caicos Islands"},
                          new SelectListItem(){ Text="Tuvalu", Value="Tuvalu"},
                          new SelectListItem(){ Text="Uganda", Value="Uganda"},
                          new SelectListItem(){ Text="Ukraine", Value="Ukraine"},
                          new SelectListItem(){ Text="United Arab Emirates", Value="United Arab Emirates"},


                
                          new SelectListItem(){ Text="United Kingdom", Value="United Kingdom"},
        
        
                   

                
                          new SelectListItem(){ Text="United States", Value="United States"},
                          new SelectListItem(){ Text="United States Minor Outlying Islands", Value="United States Minor Outlying Islands"},
                          new SelectListItem(){ Text="Uruguay", Value="Uruguay"},
                          new SelectListItem(){ Text="Uzbekistan", Value="Uzbekistan"},
                          new SelectListItem(){ Text="Vanuatu", Value="Vanuatu"},
                          new SelectListItem(){ Text="Venezuela", Value="Venezuela"},

               
                          new SelectListItem(){ Text="Viet Nam", Value="Viet Nam"},
                          new SelectListItem(){ Text="Virgin Islands, British", Value="Virgin Islands, British"},
                          new SelectListItem(){ Text="Virgin Islands, U.s.", Value="Virgin Islands, U.s."},
                          new SelectListItem(){ Text="Wallis and Futuna", Value="Wallis and Futuna"},
                          new SelectListItem(){ Text="Western Sahara", Value="Western Sahara"},
                          new SelectListItem(){ Text="Yemen", Value="Yemen"},
        
                          new SelectListItem(){ Text="Zambia", Value="Zambia"},
          
                          new SelectListItem(){ Text="Zimbabwe", Value="Zimbabwe"},};

        public static List<SelectListItem> status = new List<SelectListItem>()
        {
            

            new SelectListItem(){ Text="Awaiting Payment", Value="awaiting_payment"},
                new SelectListItem(){ Text="Payment Done", Value="payment_done"},
                new SelectListItem(){ Text="Task In Progress", Value="task_in_progress"},
                new SelectListItem(){ Text="Task Completed", Value="task_completed"},
                new SelectListItem(){ Text="Cancelled", Value="cancelled"},
                new SelectListItem(){ Text="Archived", Value="archived"}
        };


    }
     
}