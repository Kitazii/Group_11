import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import SearchPage from "../Pages/SearchPage/SearchPage";
import HomePage from "../Pages/HomePage/HomePage";
import CompanyPage from "../Pages/CompanyPage/CompanyPage";
import BusinessProfile from "../BusinessProfile/BusinessProfile";
import DesignPage from "../Pages/DesignPage/DesignPage";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {path: "", element: <HomePage />},
            {path: "search", element: <SearchPage />},
            {path: "design-page", element: <DesignPage />},
            {
                path: "company/:ticker", 
                element: <CompanyPage />,
                children: [
                    {path: "business-profile", element: <BusinessProfile />},
                ]
            },
        ],
    },
]);