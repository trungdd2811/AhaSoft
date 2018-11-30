<template>
  <header id="header">
    <div id="top-bar">
      <div class="inner">
        <div class="top-bar-left">
          <h1 class="logo">
            <router-link to="/"><img 
              src="template/images/common/logo.png" 
              alt="Ahasoft"></router-link>
          </h1>
          <p class="menu-mobile-toggle">
            <img 
              src="template/images/common/menu_btn.png" 
              alt="menu_btn">
          </p>
          <dl class="btn clearfix">
            <dt class="hide"/>
            <dd><router-link to="/sales">{{ $t('sales') }}</router-link></dd>
          </dl>
        </div>
        <dl class="top-bar-right menu-user clearfix">
          <dt class="hide"/>
          <dd class="notice">
            <b-btn 
              v-b-modal.notice-click 
              class="btn-noti"><img 
                src="template/images/common/notice.png" 
                alt="home"></b-btn><span class="noti-show">3</span>
            <b-modal 
              id="notice-click" 
              :hide-header="true" 
              ok-title="View more" 
              cancel-title="Cancel" 
              size="lg" 
              @ok="addNoticesToView">
              <form>
                <ul 
                  class="notice-click-box" 
                  style="margin-top:15px">
                  <li 
                    v-for="notice in notices" 
                    :key="notice.index">
                    <span>
                      <b-btn v-b-modal.waiting-list>{{ notice.content }}</b-btn>
                    </span>
                    <p 
                      class="blue1" 
                      @click="deleteNoticesFromView"><a href="#">X</a></p>
                  </li>
                </ul>
              </form>
            </b-modal>
            <b-modal 
              id="waiting-list" 
              :hide-footer="true" 
              title="waiting-list">
              <form>
                <div class="pop-contents2">
                  <p class="wait-block">30-08-2018 14:00~16:00 예약건이 취소되었습니다. <span style="display: block;">Resource : Adam Smith, John Smith</span></p>		
                  <article>
                    <div class="wait-tablebox">
                      <span style="font-size:13px; color:#666; margin-bottom:3px">Total 00 Client</span>
                      <table>
                        <thead>
                          <tr>
                            <td>Booking Date Time</td>
                            <td>Client Name <br>Mobile Number</td>
                            <td>Resource</td>
                            <td>Booking Items</td>
                            <td>Estimated Time</td>
                            <td>Notes</td>
                            <td>Booking</td>
                            <td>Edit</td>
                          </tr>
                        </thead>
                        <tbody>
                          <tr>
                            <td>09-03-2018 15:30</td>
                            <td>Christina Choi <br>01023458907</td>
                            <td/>
                            <td/>
                            <td>180min</td>
                            <td/>
                            <td><p class="blue1"><a href="#">Book</a></p></td>
                            <td><p class="blue1"><a href="#">Edit</a></p></td>
                          </tr>
                          <tr>
                            <td>09-03-2018 15:30</td>
                            <td>Christina Choi <br>01023458907</td>
                            <td/>
                            <td/>
                            <td>180min</td>
                            <td/>
                            <td><p class="blue1"><a href="#">Book</a></p></td>
                            <td><p class="blue1"><a href="#">Edit</a></p></td>
                          </tr>
                          <tr>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                          </tr>
                          <tr>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                          </tr>
                          <tr>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                            <td/>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                    <div 
                      id="paging" 
                      class="clearfix">
                      <span>page <strong>1</strong> of <em>25</em></span>
                      <ol>
                        <li class="next-end">&lt;&lt;</li>									
                        <li class="next">&lt;</li>
                        <li class="prev">&gt;</li>
                        <li class="prev-end">&gt;&gt;</li>
                        <li class="goto">Goto</li>
                      </ol>
                    </div>
                  </article>
                </div>
              </form>
            </b-modal>
          </dd>
          <dd><a href="#"><img 
            src="template/images/common/home.png" 
            alt="home"></a></dd>
          <dd 
            class="lang" 
            @click="switchLocale">
            <a href="#">
              <img 
                v-if="otherLocale == 'en'" 
                src="../../template/images/common/en.png">
              <img 
                v-if="otherLocale == 'kr'" 
                src="../../template/images/common/kr.png">
            </a>
          </dd>
          <dd class="myaccount-click">
            <b-dropdown 
              id="myaccount-click" 
              text="Kim Aha" 
              class="m-md-2">
              <b-dropdown-header disabled>{{ $t('account') }}</b-dropdown-header>
              <b-dropdown-item href="sub/account/UserAccounts.html">- {{ $t('user-account') }}</b-dropdown-item>
              <b-dropdown-item href="sub/account/ShopInfo.html">- {{ $t('shop-information') }}</b-dropdown-item>
              <b-dropdown-header disabled>{{ $t('payment') }}</b-dropdown-header>
              <b-dropdown-item href="sub/account/Payment_VirtualAccount.html">- {{ $t('payment') }}</b-dropdown-item>
              <b-dropdown-item href="sub/account/PaymentHistory.html">- {{ $t('payment-history') }}</b-dropdown-item>
              <b-dropdown-item href="sub/account/NetmoneyHistory.html">- {{ $t('netmoney-history') }}</b-dropdown-item>
              <b-dropdown-item href="sub/account/ExtensionHistory.html">- {{ $t('extension-of-expiry-date') }}</b-dropdown-item>
            </b-dropdown>
          </dd>
          <dd class="logout">
            <b-btn v-b-modal.logout>{{ $t('signout') }}</b-btn>
            <b-modal 
              id="logout" 
              title="Sign Out" 
              ok-title="Confirm" 
              cancel-title="Cancel" 
              size="sm">
              <form>
                <div class="pop-contents2">
                  <article>
                    <p style="margin-top:25px">정말 sign out 하시겠습니까?</p>
                  </article>		
                </div>
              </form>
            </b-modal>
          </dd>
        </dl>	
      </div>
      <div class="salon">
        <p class="local">Aha Hair Salon Anyang</p>
        <!-- <p class="Mbtn"> - Hide Menu</p>
				<p class="Mbtn2"> + Show Menu</p> -->
      </div>
    </div>	
    <nav id="menu">
      <!-- <div class="inner">
				<ul class="menu-list clearfix">
					<li><a href="sub/sales/sales.html">SALES</a>
						<div class="menu-wrap clearfix tab-sales">
							<div class="menu-box menu-box1">
								<h2>SALES REPORT</h2>
								<ul>
									<li><a href="sub/sales/Report_SalesTotal.html"><span><img src="template/images/common/icon01.png" alt=""></span>Sales Total</a></li>
									<li><a href="sub/sales/Report_SalesByStaff.html"><span><img src="template/images/common/icon02.png" alt=""></span>Sales by Staff</a></li>
									<li><a href="sub/sales/Report_SalesByItem.html"><span><img src="template/images/common/icon03.png" alt=""></span>Sales by Item</a></li>
								</ul>
							</div>
							<div class="menu-box menu-box2">
								<h2>SALES HISTORY</h2>
								<ul>
									<li><a href="sub/sales/Invoices.html"><span><img src="template/images/common/icon04.png" alt=""></span>Invoices</a></li>
									<li><a href="sub/booking/booking.html"><span><img src="template/images/common/icon01.png" alt=""></span>Bookings</a></li>
									<li><a href="sub/sales/Receivables.html"><span><img src="template/images/common/icon03.png" alt=""></span>Receivables</a></li>
								</ul>
							</div>
							<div class="menu-box menu-box3">
								<h2>POINT AND BALANCE EDIT HISTORY</h2>
								<ul>
									<li><a href="sub/sales/point-balance-edit.html"><span><img src="template/images/common/icon04.png" alt=""></span>Point and Balance Edit History</a></li>
								</ul>
							</div>
						</div>
					</li>
					<li><a href="#">CLIENTS</a>
						<div class="menu-wrap clearfix tab-client">
							<div class="menu-box menu-box1">
								<h2>CLIENTS</h2>
								<ul>
									<li><a href="sub/clients/client.html"><span><img src="template/images/common/icon01.png" alt=""></span>Clients</a></li>
									<li><a href="sub/clients/duplicated-clients.html"><span><img src="template/images/common/icon02.png" alt=""></span>Duplicated Clients</a></li>
									<li><a href="sub/clients/deleted-clients.html"><span><img src="template/images/common/icon03.png" alt=""></span>Deleted Clients</a></li>
								</ul>
							</div>
							<div class="menu-box menu-box2">
								<h2>CLIENT MANAGEMENT</h2>
								<ul>
									<li><a href="sub/clients/clients-management1.html"><span><img src="template/images/common/icon04.png" alt=""></span>Client Management</a></li>
									<li><a href="sub/clients/campaign-management.html"><span><img src="template/images/common/icon05.png" alt=""></span>Campaign Management</a></li>
								</ul>
							</div>
							<div class="menu-box menu-box3">
								<h2>MESSAGES</h2>
								<ul>
									<li><a href="sub/clients/text-message-history.html"><span><img src="template/images/common/icon07.png" alt=""></span>Messaging History</a></li>
									<li><a href="sub/clients/setup-automatic-messaging.html"><span><img src="template/images/common/icon08.png" alt=""></span>Setup Automatic Messaging</a></li>
								</ul>
							</div>
						</div>	
					</li>
					<li><a href="#">STAFF</a>
						<div class="menu-wrap clearfix tab-staff">
							<h2></h2>
							<div class="menu-box menu-box1">
								<ul>
									<li><a href="sub/staff/time-sheet.html"><span><img src="template/images/common/icon01.png" alt=""></span>Time Clock</a></li>
									<li><a href="sub/staff/staff-goal.html"><span><img src="template/images/common/icon02.png" alt=""></span>Staff Goal</a></li>
									<li><a href="sub/staff/payroll-statemen.html"><span><img src="template/images/common/icon03.png" alt=""></span>Payroll</a></li>
									<li><a href="sub/staff/staffs.html"><span><img src="template/images/common/icon05.png" alt=""></span>Staffs</a></li>
								</ul>
							</div>
						</div>
					</li>
					<li><a href="#">INVENTORY</a>
						<div class="menu-wrap clearfix tab-inventory">
							<div class="menu-box menu-box1">
								<h2>STOCK MANAGEMENT</h2>
								<ul>
									<li><a href="sub/inventory/purchase.html"><span><img src="template/images/common/icon01.png" alt=""></span>Purchase</a></li>
									<li><a href="sub/inventory/purchase.html"><span><img src="template/images/common/icon01.png" alt=""></span>Purchases</a></li>
									<li><a href="sub/inventory/stock-internal-use.html"><span><img src="template/images/common/icon02.png" alt=""></span>Internal Use</a></li>
									<li><a href="sub/inventory/adjust-stock.html"><span><img src="template/images/common/icon03.png" alt=""></span>Stock Adjustment</a></li>
									<li><a href="sub/inventory/stock-history.html"><span><img src="template/images/common/icon05.png" alt=""></span>Stock History</a></li>
									<li><a href="sub/inventory/stock-status.html"><span><img src="template/images/common/icon01.png" alt=""></span>Stock Status</a></li>
								</ul>
							</div>
							<div class="menu-box menu-box2">
								<h2>SUPPLIERS</h2>
								<ul>
									<li><a href="sub/inventory/Suppliers.html"><span><img src="template/images/common/icon04.png" alt=""></span>suppliers</a></li>
								</ul>
							</div>
						</div>
					</li>		
					<li><a href="#">EXPENDITURE</a>
						<div class="menu-wrap clearfix tab-expenditure">
							<div class="menu-box menu-box1">
								<ul>
									<li><a href="sub/expenditure/AddExpenditure.html"><span><img src="template/images/common/icon01.png" alt=""></span>Add Expenditure</a></li>
									<li><a href="sub/expenditure/ExpenditureHistory.html"><span><img src="template/images/common/icon02.png" alt=""></span>Expenditure History</a></li>
									<li><a href="sub/expenditure/ExpenditureSummary.html"><span><img src="template/images/common/icon03.png" alt=""></span>Expenditure Summary</a></li>
									<li><a href="sub/expenditure/ExpenditureItems.html"><span><img src="template/images/common/icon04.png" alt=""></span>Expenditure Items</a></li>
								</ul>
							</div>
						</div>
					</li>
					<li><a href="#">REPORT</a>
						<div class="menu-wrap clearfix tab-report">
							<div class="menu-box menu-box1">
								<h2><a href="sub/report/report_menu_page.html">SHOW MENU</a></h2>
							</div>
						</div>
					</li>
					<li><a href="#">SETUP</a>
						<div class="menu-wrap clearfix tab-setup">
							<div class="menu-box menu-box1">
								<h2>SERVICES &amp; PRODUCTS</h2>
								<ul>
									<li><a href="sub/setup/services.html"><span><img src="template/images/common/icon01.png" alt=""></span>Services</a></li>
									<li><a href="sub/setup/PrepaidCards.html"><span><img src="template/images/common/icon02.png" alt=""></span>Prepaid Cards</a></li>
									<li><a href="sub/setup/Packages.html"><span><img src="template/images/common/icon04.png" alt=""></span>Packages</a></li>
									<li><a href="sub/setup/Products.html"><span><img src="template/images/common/icon01.png" alt=""></span>Products</a></li>									
									<li><a href="sub/setup/ProductCategory.html"><span><img src="template/images/common/icon01.png" alt=""></span>Product Categories</a></li>
								</ul>
							</div>
							<div class="menu-box menu-box2">
								<h2>BASIC SETUP</h2>
								<ul>
									<li><a href="sub/setup/MiscellaneousCodesSetup.html"><span><img src="template/images/common/icon01.png" alt=""></span>Misc.Codes</a></li>
									<li><a href="sub/setup/RoyaltyPointsSetup.html"><span><img src="template/images/common/icon07.png" alt=""></span>Royalty Points Setup</a></li>
									<li><a href="sub/setup/EnvironmentSetup.html"><span><img src="template/images/common/icon07.png" alt=""></span>Environment Setup</a></li>
								</ul>
							</div>
							<div class="menu-box menu-box3">
								<h2>DEVICE INTERFACE</h2>
								<ul>
									<li><a href="sub/setup/CIDsetup.html"><span><img src="template/images/common/icon07.png" alt=""></span>Caller ID Setup</a></li>
								</ul>
							</div>
						</div>
					</li>
					<li><a href="#">SUPPORT</a></li>
				</ul>
			</div> -->
    </nav>
    <div id="menu-mobile">
      <ul class="clearfix">
        <li><a href="index.html">HOME</a></li>
        <li><a href="sub/sales/sales.html">SALES</a></li>
        <li><a href="sub/booking/booking.html">BOOKINGS</a></li>
        <li><a href="#">MYPAGE</a></li>
      </ul>
    </div>
    <nav id="menu-mobile-full">
      <div class="inner">
        <h2 class="logo2"><a href="index.html"><img 
          src="template/images/common/logo2.png" 
          alt="Ahasoft"></a></h2>
        <p class="btn-close">
          <img 
            src="template/images/common/closebtn.png" 
            alt="close_btn">
        </p>
        <div class="profile">
          <div class="photo"><img 
            src="template/images/common/ex_profileimg.png" 
            alt="예시이미지"></div>
          <h3>Kim Aha</h3>
          <span>Ahashop Anyang</span>
          <span class="logout"><a href="#">Signout</a></span>
        </div>
        <ul class="menu-list clearfix">
          <li><a href="#"><img 
            src="template/images/common/sales.png" 
            alt="sales">SALES</a>
            <div class="menu-wrap clearfix tab-sales">
              <div class="menu-box menu-box1">
                <h2>SALES REPORT</h2>
                <ul>
                  <li><a href="sub/sales/Sales.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Sales</a></li>
                  <li><a href="sub/sales/Report_SalesTotal.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Sales Total</a></li>
                  <li><a href="sub/sales/Report_SalesByStaff.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Sales by Staff</a></li>
                  <li><a href="sub/sales/Report_SalesByItem.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Sales by Item</a></li>
                </ul>
              </div>
              <div class="menu-box menu-box2">
                <h2>SALES HISTORY</h2>
                <ul>
                  <li><a href="sub/sales/Invoices.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Invoices</a></li>
                  <li><a href="sub/booking/booking.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Bookings</a></li>
                  <li><a href="sub/sales/Receivables.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Receivables</a></li>
                </ul>
              </div>
              <div class="menu-box menu-box3">
                <ul>
                  <li><a href="sub/sales/point-balance-edit.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Point and Balance Edit History</a></li>
                </ul>
              </div>
            </div>
          </li>
          <li><a href="#"><img 
            src="template/images/common/clients.png" 
            alt="clients">CLIENTS</a>
            <div class="menu-wrap clearfix tab-client">
              <div class="menu-box menu-box1">
                <h2>CLIENTS</h2>
                <ul>
                  <li><a href="sub/clients/client.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Clients</a></li>
                  <li><a href="sub/clients/duplicated-clients.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Duplicated Clients</a></li>
                  <li><a href="sub/clients/deleted-clients.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Deleted Clients</a></li>
                </ul>
              </div>
              <div class="menu-box menu-box2">
                <h2>CLIENT MANAGEMENT</h2>
                <ul>
                  <li><a href="sub/clients/clients-management1.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Clients Management</a></li>
                  <li><a href="sub/clients/campaign-management.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Campaign Management</a></li>
                </ul>
              </div>
              <div class="menu-box menu-box3">
                <h2>MESSAGES</h2>
                <ul>
                  <li><a href="sub/clients/text-message-history.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Messaging History</a></li>
                  <li><a href="sub/clients/setup-automatic-messaging.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Setuo Automatic Messaging</a></li>
                </ul>
              </div>
            </div>	
          </li>
          <!-- <li><a href="#"><img src="template/images/common/inventory.png" alt="staff">STAFF</a> -->
          <li><a href="#"><img 
            src="template/images/common/clients.png" 
            alt="staff">STAFF</a>
            <div class="menu-wrap clearfix tab-staff">
              <div class="menu-box menu-box1">
                <ul>
                  <li><a href="sub/staff/time-sheet.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Time Clock</a></li>
                  <li><a href="sub/staff/staff-goal.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Staff Goal</a></li>
                  <li><a href="sub/staff/payroll-statemen.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Payroll</a></li>
                  <li><a href="sub/staff/staffs.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Staffs</a></li>
                </ul>
              </div>
            </div>
          </li>
          <!-- <li><a href="#"><img src="template/images/common/inventory.png" alt="inventory">INVENTORY</a> -->
          <li><a href="#"><img 
            src="template/images/common/clients.png" 
            alt="staff">STAFF</a>
            <div class="menu-wrap clearfix tab-inventory">
              <div class="menu-box menu-box1">
                <h2>STOCK MANAGEMENT</h2>
                <ul>
                  <li><a href="sub/inventory/purchase.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Purchase</a></li>
                  <li><a href="sub/inventory/purchase.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Purchases</a></li>
                  <li><a href="sub/inventory/stock-internal-use.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Internal Use</a></li>
                  <li><a href="sub/inventory/adjust-stock.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Stock Adjustment</a></li>
                  <li><a href="sub/inventory/stock-history.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Stock History</a></li>
                  <li><a href="sub/inventory/stock-status.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Stock Status</a></li>
                </ul>
              </div>
              <div class="menu-box menu-box2">
                <h2>SUPPLIERS</h2>
                <ul>
                  <li><a href="sub/inventory/suppliers.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>suppliers</a></li>
                </ul>
              </div>
            </div>
          </li>
          <li><a href="#"><img 
            src="template/images/common/expenditure.png" 
            alt="expenditure">EXPENDITURE</a>
            <div class="menu-wrap clearfix tab-expenditure">
              <div class="menu-box menu-box1">
                <ul>
                  <li><a href="sub/expenditure/AddExpenditure.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Add Expenditure</a></li>
                  <li><a href="sub/expenditure/ExpenditureHistory.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Expenditures</a></li>
                  <li><a href="sub/expenditure/ExpenditureItems.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Expenditure Summary</a></li>
                  <li><a href="sub/expenditure/ExpenditureSummary.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Expenditure Items</a></li>
                </ul>
              </div>
            </div>
          </li>
          <li><a href="sub/report/report_menu_page.html"><img 
            src="template/images/common/report.png" 
            alt="report">REPORT</a></li>
          <li><a href="#"><img 
            src="template/images/common/setup.png" 
            alt="setup">SETUP</a>
            <div class="menu-wrap clearfix tab-setup">
              <div class="menu-box menu-box1">
                <h2>SERVICES &amp; PRODUCTS</h2>
                <ul>
                  <li><a href="sub/setup/services.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Services</a></li>
                  <li><a href="sub/setup/PrepaidCards.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Prepaid Cards</a></li>
                  <li><a href="sub/setup/Packages.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Packages</a></li>
                  <li><a href="sub/setup/Products.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Products</a></li>
                  <li><a href="sub/setup/ProductCategory.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Product Categories</a></li>
                </ul>
              </div>
              <div class="menu-box menu-box2">
                <h2>BASIC SETUP</h2>
                <ul>
                  <li><a href="sub/setup/MiscellaneousCodesSetup.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Misc.Codes</a></li>
                  <li><a href="sub/setup/RoyaltyPointsSetup.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Royalty Points Setup</a></li>
                  <li><a href="sub/setup/EnvironmentSetup.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Environment Setup</a></li>
                </ul>
              </div>
              <div class="menu-box menu-box3">
                <h2>DEVICE INTERFACE</h2>
                <ul>
                  <li><a href="sub/setup/CIDsetup.html"><span><img 
                    src="template/images/common/here.png" 
                    alt=""></span>Caller ID Setup</a></li>
                </ul>
              </div>
            </div>
          </li>
          <li><a href="#"><img 
            src="template/images/common/support.png" 
            alt="support">SUPPORT</a></li>
        </ul>
        <p class="foot">
          © Copyright 2005<br>
          by AHASOFT All Right Reserved.
        </p>
      </div>
    </nav>
  </header>
</template>

<script>
import bModal from 'bootstrap-vue/es/components/modal/modal'
import { mapGetters } from 'vuex'

export default {
    components: {
        'b-modal': bModal
    },
    computed: {
        // notice
        ...mapGetters('header_block', {
            notices: 'getNotices'
        }),
        // language
        otherLocale() {
            let other =  'kr'
            if (this.$i18n.locale == 'kr') other = 'en'
            return other
        }
    },
    methods: {
        // notice
        addNoticesToView (e) {
            e.preventDefault()
            this.$store.dispatch('header_block/addNoticesToView')
        },
        deleteNoticesFromView (e){
            e.preventDefault()
            this.$store.dispatch('header_block/deleteNoticesFromView')
        },
        // language
        switchLocale (e){
            e.preventDefault()
            if(this.$i18n.locale == 'en') this.$i18n.locale = 'kr'
            else this.$i18n.locale = 'en'
        }
    }
}

</script>

<style lang='scss'>
@import './header-block.scss';

</style>
