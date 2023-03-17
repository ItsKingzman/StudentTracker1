// Export the variable records and the function populateStudentReports
export let records = [];
// Populate the variable records with the data from an api
export async function  populateStudentReports() {
  // Declare a variable 'response' and set it to the data returned when calling the api/studentreport endpoint
  const response = await fetch('api/studentreport');
  // Declare a variable 'data' and set it to the JSON data returned by the fetch
  const data = await response.json();
  // Log the data being returned in the console
  console.log('DATA: ', data);
  // Set the variable records to the data being returned
  records = data;
}
// This is a JavaScript function that allows us to populate student reports from an API call.
// It uses the fetch API to asynchronously retrieve data from the API and convert it into JavaScript
// objects for further use. It stores the data in the 'records' variable which can be accessed via
// the populateStudentReports() function.
