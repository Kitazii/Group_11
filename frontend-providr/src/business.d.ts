export interface BusinessSearch {
    businessName: string;
    businessCity: string;
  }

export interface Business {
  businessName: string;
  businessPassword: string;
  businessEmail: string;
  businessTelephoneNumber: string;
  businessStreet: string;
  businessCity: string;
  businessPostcode: string;
  businessId: number;
}

export interface Customer {
  customerForename: string;
  customerSurname: string;
  customerPassword: string;
  customerEmail: string;
  customerTelephoneNumber: number;
  customerStreet: string;
  customerCity: string;
  customerPostcode: string;
  customerid: number;
}

export interface Ticket {
  serviceRequestID: number;
  serviceRequestName: string;
  serviceRequestDate: Date;
  businessId: number;
  customerId: number;
}

export interface Workers {
  serviceRequestId: number;
  serviceId: number;
  serviceWorkersQuantity: number;
}

export interface Service {
  serviceId: number;
  serviceType: string;
  serviceDescription: string;
  serviceCost: number;
}