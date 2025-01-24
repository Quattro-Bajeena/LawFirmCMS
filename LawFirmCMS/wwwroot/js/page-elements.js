'use strict';
const typeSelect = document.getElementById('type-select');
const textGroup = document.getElementById('text-group');
const binaryGroup = document.getElementById('binary-group');
const employeeGroup = document.getElementById('employee-group');
const jobOfferGroup = document.getElementById('joboffer-group');
const headingGroup = document.getElementById('heading-group');
const wideScreenGroup = document.getElementById('wide-screen-group');
const elementForm = document.getElementById('elementForm');

const textDataHeading = document.getElementById('textdata-heading');
const textDataText = document.getElementById('PageElement_TextData_TextArea');
const textDataEmployee = document.getElementById('textdata-employee');
const textDataJobOffer = document.getElementById('textdata-jobOffer');

function showProperInputs(selectedValue) {
    if (selectedValue == 'RichText') {
        textGroup.style.display = 'block';
        binaryGroup.style.display = 'none';
        employeeGroup.style.display = 'none';
        jobOfferGroup.style.display = 'none';
        headingGroup.style.display = 'none';
        textDataHeading.disabled = true;
        textDataText.disabled = false;
        textDataEmployee.disabled = true;
        textDataJobOffer.disabled = true;

    }
    else if (selectedValue == 'Heading') {
        textGroup.style.display = 'none';
        binaryGroup.style.display = 'none';
        employeeGroup.style.display = 'none';
        jobOfferGroup.style.display = 'none';
        headingGroup.style.display = 'block';
        textDataHeading.disabled = false;
        textDataText.disabled = true;
        textDataEmployee.disabled = true;
        textDataJobOffer.disabled = true;

    }
    else if (selectedValue == 'Image') {
        textGroup.style.display = 'none';
        binaryGroup.style.display = 'block';
        employeeGroup.style.display = 'none';
        jobOfferGroup.style.display = 'none';
        headingGroup.style.display = 'none';
        textDataHeading.disabled = true;
        textDataText.disabled = true;
        textDataEmployee.disabled = true;
        textDataJobOffer.disabled = true;

    }
    else if (selectedValue == 'Employee') {
        textGroup.style.display = 'none';
        binaryGroup.style.display = 'none';
        employeeGroup.style.display = 'block';
        jobOfferGroup.style.display = 'none';
        headingGroup.style.display = 'none';
        textDataHeading.disabled = true;
        textDataText.disabled = true;
        textDataEmployee.disabled = false;
        textDataJobOffer.disabled = true;

    }
    else if (selectedValue == "ScreenWideImage") {
        textGroup.style.display = 'block';
        binaryGroup.style.display = 'block';
        employeeGroup.style.display = 'none';
        jobOfferGroup.style.display = 'none';
        headingGroup.style.display = 'none';
        textDataHeading.disabled = true;
        textDataText.disabled = false;
        textDataEmployee.disabled = true;
        textDataJobOffer.disabled = true;
    }
    else if (selectedValue == "JobOffer") {
        textGroup.style.display = 'none';
        binaryGroup.style.display = 'none';
        employeeGroup.style.display = 'none';
        jobOfferGroup.style.display = 'block';
        headingGroup.style.display = 'none';
        textDataHeading.disabled = true;
        textDataText.disabled = true;
        textDataEmployee.disabled = true;
        textDataJobOffer.disabled = false;
    }
}

if (typeSelect) {
    showProperInputs(typeSelect.value);
    textDataText.disabled = false;
    typeSelect.addEventListener('change', (event) => {
        const selectedValue = event.target.value;
        showProperInputs(selectedValue);
    });

}

elementForm.addEventListener('submit', (event) => {
    showProperInputs(typeSelect.value);
});

CKEDITOR.replace('PageElement_TextData_TextArea', {
    versionCheck: false,
    height: 300,
    toolbar: [
        { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline'] },
        { name: 'paragraph', items: ['NumberedList', 'BulletedList'] },
        { name: 'links', items: ['Link', 'Unlink'] },
        { name: 'insert', items: ['Image', 'Table'] },
        { name: 'tools', items: ['Maximize'] },
        { name: 'styles', items: ['Format', 'FontSize'] }
    ]

});

showProperInputs(typeSelect.value);