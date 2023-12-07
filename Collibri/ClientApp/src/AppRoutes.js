import LoginPage from "./components/LoginPage";
import {Navigate} from "react-router-dom";
import {LandingPageLayout} from "./components/Layouts/LandingPageLayout";
import RoomLayout from "./components/Layouts/RoomLayout";
import ResetPasswordPage from "./components/ResetPasswordPage";
import AboutPage from "./components/AboutPage";


const AppRoutes = [
  {
    index: true,
    element: <Navigate to="/login"/>
  },
  {
    path: '/home',
    element: <LandingPageLayout />
  },
  {
    path: '/:roomId',
    element: <RoomLayout />
  },
  {
    path: '/login',
    element: <LoginPage />
  },
  {
    path : '/reset-password/:token', 
    element: <ResetPasswordPage />
  },
  {
    path: '/about',
    element: <AboutPage />
  }
    
];

export default AppRoutes;
