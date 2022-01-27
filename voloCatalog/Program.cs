// See https://aka.ms/new-console-template for more information

global using OstToolsDataLayer.CetCatalogEf;

/* Add Aluminum Framing Alternative Graphics To Doors */

//New External Ref Keys
//var ex0 = new voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors.AddNewExternalRefKey();

////Slide
//var ex1 = new voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors.AddNewAlumModels();
//var ex2 = new voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors.AddAlumExternalRefsToProducts();
//var ex3 = new voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors.AddExternalRefKeyToExternalRef();

////Swing
//var ex4 = new voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors.AddNewSwingAlumModels();
//var ex5 = new voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors.AddSwingAlumExternalRefsToProducts();
//var ex6 = new voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors.AddSwingExternalRefKeyToExternalRef();

//ex0.run();
//ex1.run();
//ex2.run();
//ex3.run();
//ex4.run();
//ex5.run();
//ex6.run();

/* Add the Door Hardware */
//var ex0 = new voloCatalog.RemoveExtRefFromFrameless.RemoveExtRef();

/* Price Update for Volo */
var ex0 = new voloCatalog.VoloDataUpdate.UpdatePrice();

ex0.run();




