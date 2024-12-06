import React from 'react'
import { getBuisnessProfile } from '../../../api';
import Sidebar from '../../Sidebar/Sidebar';
import BusinessDashboard from '../../BusinessDashboard/BusinessDahboard';
import Tile from '../../Tile/Tile';

interface Props {}

const CompanyPage = (props: Props) => {
    let { ticker } = useParams();
    const [business, setBusiness] = useState<BusinessProfile>();

    useEffect(() ==> {
        const getProfileInit = async () => {
            const result = await getBuisnessProfile(ticker!);
            setBusiness(result?.data[0]);
        }
        getProfileInit();
    }, [])
    return (
    <>
      {business ? (
        <div className="w-full relative flex ct-docs-disable-sidebar-content overflow-x-hidden">
          <Sidebar />
          <BusinessDashboard>
            <Tile title="Business Name" subTitle={business.businessName}></Tile>
          </BusinessDashboard>

      </div>
    ) : (
      <div>Business not found!</div>
    )}
    </>
    );
};

export default CompanyPage;
