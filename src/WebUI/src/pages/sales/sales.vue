<template>
  <div id="container">
    <section id="content">
      <div class="inner_1400">
        <article 
          id="Sales_top" 
          class="clearfix show">
          <div class="searchBox clearfix">
            <p class="down_btn"><img 
              src="template/images/contents/down_white.png" 
              alt="">
              <span class="client-search-list">
                <em><a href="#">Client Name or Mobile</a></em>
                <em><a href="#">Client Name or Member no.</a></em>
                <em><a href="#">Notes</a></em>
              </span>
            </p>
            <input 
              type="text" 
              value="Client Name or Mobile">
            <p class="search_btn"><a href="#"><img 
              src="template/images/contents/search_btn.png" 
              alt="검색"></a></p>
          </div>
          <div class="chk">
            <input 
              id="a1" 
              type="checkbox" 
              name="Search in All Branches" >
            <label for="a1"><span>Search in All Branches</span></label>
          </div>
          <div class="right_btnBox m-show">
            <ul class="clearfix">
              <li class="b1"><a href="Walk_in_sales_history.html">Walk-in</a></li>
              <li class="b2"><a 
                href="#" 
                data-toggle="modal" 
                data-target="#add-client">Add Client</a></li>
            </ul>
          </div>
        </article>

        <!-- <div class="upbtn"><img src="template/images/contents1/up_gray.png" alt="up_gray"></div> -->
        <article id="Sales_tab">
          <!-- <div class="tabBox">
            <ul class="clearfix">
              <li class="on">Invoice</li>
              <li>Booking</li>
              <li>Prepaid Cards</li>
              <li>Prepaid Services</li>
              <li>Messages</li>
              <li>Photos</li>
            </ul>
          </div> -->
          <!-- //////////-->
          <div class="innerBox pc">
            <div>
              <h3>Total 00 Clients &nbsp;&nbsp;&nbsp;<strong style="color:#db3131">*Click row to select client</strong></h3>
              <table>
                <thead>
                  <tr>
                    <td>Location</td>
                    <td>Client Name</td>
                    <td>Mobile/Phone</td>
                    <td>Date of<br>Birth</td>
                    <td>Prefferred Staff</td>
                    <td>Recent Visit Date</td>
                    <td width="25%">Notes</td>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td/>
                    <td><a href="Client_Invoice.html">Bruno Mars</a></td>
                    <td>010-222-3333<br>/031-890-7654</td>
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
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
          <div class="MinnerBox">
            <div>
              <table>
                <thead>
                  <tr>
                    <td>Total 00 Clients</td>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td><a href="Client_Invoice.html"><strong>Bruno Mars</strong><br>010-222-3333/031-890-7654</a><span>&gt;</span></td>
                  </tr>
                  <tr>
                    <td><a href="#"><strong>Bruno Mars</strong><br>010-222-3333/031-890-7654</a><span>&gt;</span></td>
                  </tr>
                  <tr>
                    <td/>
                  </tr>
                  <tr>
                    <td/>
                  </tr>
                  <tr>
                    <td/>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </article>
        <div 
          id="paging" 
          class="clearfix">
          <span>page <strong>1</strong> of <em>25</em></span>
          <ol>
            <li class="next_end">&lt;&lt;</li>
            <li class="next">&lt;</li>
            <li class="prev">&gt;</li>
            <li class="prev_end">&gt;&gt;</li>
            <li class="Goto">Goto</li>
          </ol>
        </div>
      </div>
    </section>
  </div>

</template>

<script>
export default {
    components: {
    
    }
}
</script>


<style lang='scss' scoped>
@import './sales.scss';

</style>
