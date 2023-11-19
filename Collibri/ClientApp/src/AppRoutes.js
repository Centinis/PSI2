import LoginPage from "./components/LoginPage";
import {LandingPageLayout} from "./components/Layouts/LandingPageLayout";
import RoomLayout from "./components/Layouts/RoomLayout";
import {AboutPage} from "./components/AboutPage";


const AppRoutes = [
  {
    index: true,
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
    path: '/about',
    element: <AboutPage />
  }
    
];

export default AppRoutes;
