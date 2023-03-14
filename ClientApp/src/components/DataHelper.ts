export let records = [];
export async function  populateStudentReports() {
  const response = await fetch('api/studentreport');
  const data = await response.json();
  console.log('DATA: ', data);
  records = data;
}
